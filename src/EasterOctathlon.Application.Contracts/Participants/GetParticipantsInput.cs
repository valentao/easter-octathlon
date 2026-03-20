using Volo.Abp.Application.Dtos;

namespace EasterOctathlon.Participants;

public class GetParticipantsInput : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
