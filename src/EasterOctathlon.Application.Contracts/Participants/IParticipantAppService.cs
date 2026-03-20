using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasterOctathlon.Participants;

public interface IParticipantAppService : IApplicationService
{
    Task<ParticipantDto> GetAsync(int id);

    Task<PagedResultDto<GetParticipantListDto>> GetListAsync(GetParticipantsInput input);

    Task<ParticipantDto> CreateAsync(CreateUpdateParticipantDto input);

    Task<ParticipantDto> UpdateAsync(int id, CreateUpdateParticipantDto input);

    Task DeleteAsync(int id);
}

