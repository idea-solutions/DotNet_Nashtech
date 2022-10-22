using Assignment02.Data;
using Assignment02.Models;

namespace Assignment02.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductStoreContext context) : base(context)
    {

    }
}