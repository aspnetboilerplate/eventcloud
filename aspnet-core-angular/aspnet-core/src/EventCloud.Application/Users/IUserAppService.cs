using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EventCloud.Roles.Dto;
using EventCloud.Users.Dto;

namespace EventCloud.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
