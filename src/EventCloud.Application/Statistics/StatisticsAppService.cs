using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using EventCloud.Events;
using EventCloud.MultiTenancy;
using EventCloud.Users;

namespace EventCloud.Statistics
{
    public class StatisticsAppService : EventCloudAppServiceBase, IStatisticsAppService
    {
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;

        public StatisticsAppService(
            IRepository<Tenant> tenantRepository,
            IRepository<User, long> userRepository,
            IRepository<Event, Guid> eventRepository,
            IRepository<EventRegistration> eventRegistrationRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _eventRegistrationRepository = eventRegistrationRepository;
        }

        public async Task<ListResultOutput<NameValueDto>> GetStatistics()
        {
            //Disabled filters to access to all tenant's data, not for only current tenant.
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant, AbpDataFilters.MustHaveTenant))
            {
                var statisticItems = new List<NameValueDto>
                {
                    new NameValueDto(
                        L("Tenants"),
                        (await _tenantRepository.CountAsync()).ToString()
                        ),
                    new NameValueDto(
                        L("Users"),
                        (await _userRepository.CountAsync()).ToString()
                        ),
                    new NameValueDto(
                        L("Events"),
                        (await _eventRepository.CountAsync()).ToString()
                        ),
                    new NameValueDto(
                        L("Registrations"),
                        (await _eventRegistrationRepository.CountAsync()).ToString()
                        )
                };

                return new ListResultOutput<NameValueDto>(statisticItems);
            }
        }
    }
}
