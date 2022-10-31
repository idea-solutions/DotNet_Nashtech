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
                var category = _categoryRepository.GetById(s => s.Id == createModel.CategoryId);

                if (category == null)
                {
                    return null;
                }

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
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }

    public bool Delete(int id)
    {
        using (var transaction = _productRepository.EntityDbTransaction())
        {
            try
            {
                var product = _productRepository.GetById(s => s.Id == id);

                if (product == null)
                {
                    return false;
                }

                _productRepository.Delete(product);

                _productRepository.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();

                return false;
            }
        }
    }

    public IEnumerable<GetProductResponse>? GetAll()
    {
        using (var transaction = _productRepository.EntityDbTransaction())
        {
            try
            {
                var listProduct = _productRepository.GetAll().Select(d => new GetProductResponse
                {
                    ProductId = d.Id,
                    ProductName = d.ProductName,
                    Manufacture = d.Manufacture,
                    CategoryId = d.CategoryId
                });

                _productRepository.SaveChanges();

                transaction.Commit();

                return listProduct;
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }

    public GetProductResponse? GetById(int id)
    {
        using (var transaction = _productRepository.EntityDbTransaction())
        {
            try
            {
                var product = _productRepository.GetById(d => d.Id == id);

                if (product == null)
                {
                    return null;
                }

                _productRepository.SaveChanges();

                transaction.Commit();

                return new GetProductResponse
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Manufacture = product.Manufacture,
                    CategoryId = product.CategoryId
                };
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }

    public UpdateProductResponse? Update(int id, UpdateProductRequest updateModel)
    {
        using (var transaction = _productRepository.EntityDbTransaction())
        {
            try
            {
                var category = _categoryRepository.GetById(s => s.Id == updateModel.CategoryId);

                if (category == null)
                {
                    return null;
                }

                var product = _productRepository.GetById(d => d.Id == id);

                if (product == null)
                {
                    return null;
                }

                product.ProductName = updateModel.ProductName;
                product.Manufacture = updateModel.Manufacture;
                product.CategoryId = updateModel.CategoryId;

                var updatedProduct = _productRepository.Update(product);

                _categoryRepository.SaveChanges();

                transaction.Commit();

                return new UpdateProductResponse
                {
                    ProductId = updatedProduct.Id,
                    ProductName = updatedProduct.ProductName,
                    Manufacture = updatedProduct.Manufacture,
                    CategoryId = updatedProduct.CategoryId
                };
            }
            catch
            {
                transaction.Rollback();

                return null;
            }
        }
    }
}