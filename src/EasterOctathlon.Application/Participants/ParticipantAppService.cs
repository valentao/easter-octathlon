using System;
using System.Linq;
using System.Threading.Tasks;
using EasterOctathlon.Permissions;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace EasterOctathlon.Participants;

public class ParticipantAppService : EasterOctathlonAppService, IParticipantAppService
{
    private readonly IRepository<Participant, int> _participantRepository;
    private readonly ParticipantMapper _participantMapper;

    public ParticipantAppService(
        IRepository<Participant, int> participantRepository,
        ParticipantMapper participantMapper)
    {
        _participantRepository = participantRepository;
        _participantMapper = participantMapper;
    }

    [Authorize(EasterOctathlonPermissions.Participants.Default)]
    public async Task<ParticipantDto> GetAsync(int id)
    {
        var participant = await _participantRepository.GetAsync(id);
        return _participantMapper.MapToDto(participant);
    }

    [Authorize(EasterOctathlonPermissions.Participants.Default)]
    public async Task<PagedResultDto<GetParticipantListDto>> GetListAsync(GetParticipantsInput input)
    {
        var queryable = await _participantRepository.GetQueryableAsync();

        if (!string.IsNullOrWhiteSpace(input.Filter))
        {
            var filter = input.Filter.Trim();
            queryable = queryable.Where(x =>
                x.FirstName.Contains(filter) ||
                x.LastName.Contains(filter) ||
                (x.NickName != null && x.NickName.Contains(filter)));
        }

        var totalCount = await AsyncExecuter.CountAsync(queryable);
        var sorting = string.IsNullOrWhiteSpace(input.Sorting)
            ? $"{nameof(Participant.LastName)}, {nameof(Participant.FirstName)}"
            : input.Sorting;

        var participants = await AsyncExecuter.ToListAsync(
            queryable
                .OrderBy(sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

        return new PagedResultDto<GetParticipantListDto>(
            totalCount,
            _participantMapper.MapToListDtoList(participants));
    }

    [Authorize(EasterOctathlonPermissions.Participants.Create)]
    public async Task<ParticipantDto> CreateAsync(CreateUpdateParticipantDto input)
    {
        var participant = new Participant(
            GuidGenerator.Create(),
            input.FirstName,
            input.LastName,
            input.NickName,
            input.Gender,
            input.DateOfBirth,
            input.IsActive,
            input.Note);

        participant = await _participantRepository.InsertAsync(participant, autoSave: true);
        return _participantMapper.MapToDto(participant);
    }

    [Authorize(EasterOctathlonPermissions.Participants.Edit)]
    public async Task<ParticipantDto> UpdateAsync(int id, CreateUpdateParticipantDto input)
    {
        var participant = await _participantRepository.GetAsync(id);
        participant.Update(
            input.FirstName,
            input.LastName,
            input.NickName,
            input.Gender,
            input.DateOfBirth,
            input.IsActive,
            input.Note);

        participant = await _participantRepository.UpdateAsync(participant, autoSave: true);
        return _participantMapper.MapToDto(participant);
    }

    [Authorize(EasterOctathlonPermissions.Participants.Delete)]
    public async Task DeleteAsync(int id)
    {
        await _participantRepository.DeleteAsync(id);
    }
}

