using thetaREST.Application.TaskLists.Commands.CreateTaskList;
using thetaREST.Application.TaskLists.Commands.DeleteTaskList;
using thetaREST.Application.TaskLists.Commands.UpdateTaskList;
using thetaREST.Application.TaskLists.Queries.GetTasks;

namespace thetaREST.Web.Endpoints;

public class TaskLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTaskLists)
            .MapPost(CreateTaskList)
            .MapPut(UpdateTaskList, "{id}")
            .MapDelete(DeleteTaskList, "{id}");
    }

    public async Task<TasksVm> GetTaskLists(ISender sender)
    {
        return await sender.Send(new GetTasksQuery());
    }

    public async Task<int> CreateTaskList(ISender sender, CreateTaskListCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateTaskList(ISender sender, int id, UpdateTaskListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTaskList(ISender sender, int id)
    {
        await sender.Send(new DeleteTaskListCommand(id));
        return Results.NoContent();
    }
}
