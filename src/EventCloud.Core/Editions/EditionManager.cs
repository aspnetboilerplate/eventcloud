using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;

namespace EventCloud.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public EditionManager(
            IRepository<Edition> editionRepository,
            IRepository<EditionFeatureSetting, long> editionFeatureRepository)
            : base(
                editionRepository,
                editionFeatureRepository)
        {
        }
    }
}
