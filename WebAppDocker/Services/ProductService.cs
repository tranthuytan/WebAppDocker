using WebAppDocker.Database.Entities;
using WebAppDocker.Database.Repositories;

namespace WebAppDocker.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product Add(Product product)
        {
            return  _productRepository.AddAsync(product);
        }
        public async Task<Product> GetById(int id)
        {
            return await _productRepository.Find(id);
        }
        public List<Product> GetAll()
        {
            var result =  _productRepository.GetAll();
            return result.ToList();
        }
        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }
        public async Task Delete(int id)
        {
            var product = await _productRepository.Find(id);
            await _productRepository.Delete(product);
        }
    }
}
