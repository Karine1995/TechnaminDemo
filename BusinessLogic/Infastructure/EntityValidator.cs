using DAL;
using DAL.Entities;
using System.Threading.Tasks;

namespace BLL.Infastructure
{
    internal abstract class EntityValidator<TEntity> where TEntity : BaseEntity
    {
        protected readonly TechnaminDemoDbContext DbContext;

        public EntityValidator(TechnaminDemoDbContext dbContext) => DbContext = dbContext;

        public abstract Task ValidateAsync(TEntity entity);
    }
}
