using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.TaskItems.Queries;
using thetaREST.Application.Common.Models;
using thetaREST.Application.TaskItems.Commands.CreateTaskItem;
using thetaREST.Application.TaskItems.Commands.DeleteTaskItem;
using thetaREST.Application.TaskItems.Commands.UpdateTaskItem;
using thetaREST.Application.TaskItems.Commands.UpdateTaskItemDetail;
using thetaREST.Application.TaskItems.Queries.GetTaskItemsWithPagination;

namespace thetaREST.Web.Endpoints;

public class TaskItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTaskItemsWithPagination)
            .MapGet(GetTaskItemById, "{id}")
            .MapPost(CreateTaskItem)
            .MapPut(UpdateTaskItem, "{id}")
            .MapPut(UpdateTaskItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTaskItem, "{id}");
    }
    
    public async Task<TaskItemDto?> GetTaskItemById(ISender sender, [FromRoute] string id)
    {
        if (int.TryParse(id, out var intId) == false) return null;
        var query = new GetTaskItemByIdQuery {Id = intId};
        return await sender.Send(query);
    }
    
    public async Task<PaginatedList<TaskItemDigestDto>> GetTaskItemsWithPagination(ISender sender, [AsParameters] GetTaskItemsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<int> CreateTaskItem(ISender sender, CreateTaskItemCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateTaskItem(ISender sender, int id, UpdateTaskItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateTaskItemDetail(ISender sender, int id, UpdateTaskItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTaskItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTaskItemCommand(id));
        return Results.NoContent();
    }
}
