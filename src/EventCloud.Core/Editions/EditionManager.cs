using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using EventCloud.Features;

namespace EventCloud.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public EditionManager(
            IRepository<Edition> editionRepository,
            FeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore)
        {
        }
    }
}
