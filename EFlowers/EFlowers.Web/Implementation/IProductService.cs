namespace EFlowers.Web.Implementation;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();

    Task<ProductViewModel> FindProductById(int id);

    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);

    Task<bool> DeleteProductById(int id);


}
