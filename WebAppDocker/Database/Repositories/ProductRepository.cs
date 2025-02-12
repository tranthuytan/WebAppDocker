using WebAppDocker.Database.Entities;

namespace WebAppDocker.Database.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(WebAppDockerDbContext context) : base(context)
        {
        }
    }
}
