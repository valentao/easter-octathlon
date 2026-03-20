using System;
using System.ComponentModel.DataAnnotations;

namespace EasterOctathlon.Participants;

public class CreateUpdateParticipantDto
{
    [Required]
    [StringLength(ParticipantConsts.MaxFirstNameLength)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(ParticipantConsts.MaxLastNameLength)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(ParticipantConsts.MaxNickNameLength)]
    public string? NickName { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public bool IsActive { get; set; } = true;

    [StringLength(ParticipantConsts.MaxNoteLength)]
    public string? Note { get; set; }
}
