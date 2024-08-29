

using Microsoft.EntityFrameworkCore;

public class ProductoRepository : IProductoRepository
{

    // Database
    private readonly ProductoDbContext _db;

    public ProductoRepository(ProductoDbContext db)
    {
        _db = db;
    }

    public async Task<Producto> GetProducto(int id)
    {
        return await _db.Productos.FindAsync(id);
    }

    public async Task<IEnumerable<Producto>> GetAllProductos()
    {
        var result = await _db.Productos.ToListAsync();
        return result;
    }

    public async Task<Producto> CreateProducto(Producto producto)
    {
        var result = await _db.Productos.AddAsync(producto);
        await _db.SaveChangesAsync();
        return result.Entity;
    }


    public async Task<Producto> UpdateProducto(Producto inputProducto, Producto productoToUpdate)
    {
            productoToUpdate.Nombre = inputProducto.Nombre;
            productoToUpdate.Precio = inputProducto.Precio;
            productoToUpdate.Descripcion = inputProducto.Descripcion;
            await _db.SaveChangesAsync();
            return productoToUpdate;
    }

    public async Task DeleteProducto(int id)
    {
        var result = await _db.Productos.FindAsync(id);
        if (result != null)
        {
            _db.Productos.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}