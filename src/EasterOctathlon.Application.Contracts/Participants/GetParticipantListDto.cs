using System;
using Volo.Abp.Application.Dtos;

namespace EasterOctathlon.Participants;

public class GetParticipantListDto : EntityDto<int>
{
    public Guid Uid { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? NickName { get; set; }
    public Gender Gender { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public string? Note { get; set; }
}
