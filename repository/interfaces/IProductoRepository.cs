public interface IProductoRepository {
    Task<IEnumerable<Producto>> GetAllProductos();
    Task<Producto> GetProducto(int id);
    Task<Producto> CreateProducto(Producto producto);
    Task<Producto> UpdateProducto(Producto inputProducto, Producto productoToUpdate);
    Task DeleteProducto(int id);

}