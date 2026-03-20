using System.Collections.Generic;
using Riok.Mapperly.Abstractions;

namespace EasterOctathlon.Participants;

[Mapper]
public partial class ParticipantMapper
{
    [MapperIgnoreSource(nameof(Participant.ExtraProperties))]
    [MapperIgnoreSource(nameof(Participant.ConcurrencyStamp))]
    [MapperIgnoreSource(nameof(Participant.CreationTime))]
    [MapperIgnoreSource(nameof(Participant.CreatorId))]
    [MapperIgnoreSource(nameof(Participant.LastModificationTime))]
    [MapperIgnoreSource(nameof(Participant.LastModifierId))]
    [MapperIgnoreSource(nameof(Participant.IsDeleted))]
    [MapperIgnoreSource(nameof(Participant.DeleterId))]
    [MapperIgnoreSource(nameof(Participant.DeletionTime))]
    public partial ParticipantDto MapToDto(Participant participant);

    [MapperIgnoreSource(nameof(Participant.ExtraProperties))]
    [MapperIgnoreSource(nameof(Participant.ConcurrencyStamp))]
    [MapperIgnoreSource(nameof(Participant.CreationTime))]
    [MapperIgnoreSource(nameof(Participant.CreatorId))]
    [MapperIgnoreSource(nameof(Participant.LastModificationTime))]
    [MapperIgnoreSource(nameof(Participant.LastModifierId))]
    [MapperIgnoreSource(nameof(Participant.IsDeleted))]
    [MapperIgnoreSource(nameof(Participant.DeleterId))]
    [MapperIgnoreSource(nameof(Participant.DeletionTime))]
    public partial GetParticipantListDto MapToListDto(Participant participant);

    public partial List<GetParticipantListDto> MapToListDtoList(List<Participant> participants);
}
