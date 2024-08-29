
using Microsoft.EntityFrameworkCore;

public class ProductoDbContext : DbContext {

    public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) {}

    public DbSet<Producto> Productos => Set<Producto>(); 
}