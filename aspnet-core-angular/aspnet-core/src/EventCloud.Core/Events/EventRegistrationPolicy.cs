using System;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using EventCloud.Authorization.Users;
using EventCloud.Configuration;

namespace EventCloud.Events
{
    public class EventRegistrationPolicy : IEventRegistrationPolicy
    {
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;
        private readonly ISettingManager _settingManager;

        public EventRegistrationPolicy(
            IRepository<EventRegistration> eventRegistrationRepository,
            ISettingManager settingManager
            )
        {
            _eventRegistrationRepository = eventRegistrationRepository;
            _settingManager = settingManager;
        }

        public async Task CheckRegistrationAttemptAsync(Event @event, User user)
        {
            if (@event == null) { throw new ArgumentNullException("event"); }
            if (user == null) { throw new ArgumentNullException("user"); }

            CheckEventDate(@event);
            await CheckEventRegistrationFrequencyAsync(user);
        }

        private static void CheckEventDate(Event @event)
        {
            if (@event.IsInPast())
            {
                throw new UserFriendlyException("Can not register event in the past!");
            }
        }

        private async Task CheckEventRegistrationFrequencyAsync(User user)
        {
            var oneMonthAgo = Clock.Now.AddDays(-30);
            var maxAllowedEventRegistrationCountInLast30DaysPerUser = await _settingManager.GetSettingValueAsync<int>(AppSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser);
            if (maxAllowedEventRegistrationCountInLast30DaysPerUser > 0)
            {
                var registrationCountInLast30Days = await _eventRegistrationRepository.CountAsync(r => r.UserId == user.Id && r.CreationTime >= oneMonthAgo);
                if (registrationCountInLast30Days > maxAllowedEventRegistrationCountInLast30DaysPerUser)
                {
                    throw new UserFriendlyException(string.Format("Can not register to more than {0}", maxAllowedEventRegistrationCountInLast30DaysPerUser));
                }
            }
        }
    }
}
