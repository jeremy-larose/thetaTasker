using thetaREST.Domain.Entities;

namespace thetaREST.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TaskList, LookupDto>();
            CreateMap<TaskItem, LookupDto>();
        }
    }
}
