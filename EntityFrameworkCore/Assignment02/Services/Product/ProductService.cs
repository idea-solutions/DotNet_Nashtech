using Assignment02.Models;
using Assignment02.Repositories;

namespace Assignment02.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public AddProductResponse? Create(AddProductRequest createModel)
    {

        using (var transaction = _productRepository.EntityDbTransaction())
        {
            try
            {
                var category = _categoryRepository.GetOne(s => s.Id == createModel.CategoryId);

                if (category != null)
                {
                    var newProduct = new Product
                    {
                        ProductName = createModel.ProductName,
                        Manufacture = createModel.Manufacture,
                        CategoryId = category.Id
                    };

                    var product = _productRepository.Create(newProduct);

                    _productRepository.SaveChanges();

                    transaction.Commit();

                    return new AddProductResponse()
                    {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Manufacture = product.Manufacture,
                        CategoryId = product.CategoryId
                    };
                }

                return null;
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }
}