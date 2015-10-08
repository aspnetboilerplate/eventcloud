using System;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.UI;
using EventCloud.Configuration;
using EventCloud.Users;

namespace EventCloud.Events
{
    public class EventRegistrationPolicy : EventCloudServiceBase, IEventRegistrationPolicy
    {
        private readonly IRepository<EventRegistration> _eventRegistrationRepository;

        public EventRegistrationPolicy(IRepository<EventRegistration> eventRegistrationRepository)
        {
            _eventRegistrationRepository = eventRegistrationRepository;
        }

        public async Task CheckRegistrationAttemptAsync(Event @event, User user)
        {
            if (@event == null) { throw new ArgumentNullException(nameof(@event)); }
            if (user == null) { throw new ArgumentNullException(nameof(user)); }

            CheckEventDate(@event);
            CheckUserAge(@event, user);
            await CheckEventRegistrationFrequencyAsync(user);
        }

        private static void CheckEventDate(Event @event)
        {
            if (@event.IsInPast())
            {
                throw new UserFriendlyException("Can not register event in the past!"); //TODO: Localize
            }
        }

        private static void CheckUserAge(Event @event, User user)
        {
            if (@event.MinAgeToRegister > 0)
            {
                var userAge = Clock.Now.Year - user.BirthYear;
                if (userAge < @event.MinAgeToRegister)
                {
                    throw new UserFriendlyException("Can not register to the event since user's age is not sufficient!"); //TODO: Localize
                }
            }
        }

        private async Task CheckEventRegistrationFrequencyAsync(User user)
        {
            var oneMonthAgo = Clock.Now.AddDays(-30);
            var maxAllowedEventRegistrationCountInLast30DaysPerUser = await SettingManager.GetSettingValueAsync<int>(EventCloudSettingNames.MaxAllowedEventRegistrationCountInLast30DaysPerUser);
            if (maxAllowedEventRegistrationCountInLast30DaysPerUser > 0)
            {
                var registrationCountInLast30Days = await _eventRegistrationRepository.CountAsync(r => r.UserId == user.Id && r.CreationTime >= oneMonthAgo);
                if (registrationCountInLast30Days > maxAllowedEventRegistrationCountInLast30DaysPerUser)
                {
                    throw new UserFriendlyException($"Can not register to more than {maxAllowedEventRegistrationCountInLast30DaysPerUser}"); //TODO: Localize
                }
            }
        }
    }
}