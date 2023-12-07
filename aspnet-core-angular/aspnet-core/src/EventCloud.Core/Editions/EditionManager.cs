using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;

namespace EventCloud.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository, 
            IAbpZeroFeatureValueStore featureValueStore,
            Abp.Domain.Uow.IUnitOfWorkManager unitOfWorkManager)
            : base(
                editionRepository,
                featureValueStore,unitOfWorkManager)
        {
        }
    }
}
