using Abp.Authorization.Roles;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EventCloud.Authorization;
using EventCloud.Authorization.Roles;
using EventCloud.Roles.Dto;
using EventCloud.Authorization.Users;
using EventCloud.Users.Dto;

namespace EventCloud
{
    [DependsOn(
        typeof(EventCloudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EventCloudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EventCloudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EventCloudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg =>
                {
                    // Role and permission
                    cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                    cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                    cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                    cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());


                    cfg.CreateMap<UserDto, User>();
                    cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                    cfg.CreateMap<CreateUserDto, User>();
                    cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
                }
            );
        }
    }
}
