using Microsoft.AspNetCore.Mvc;

[Route("productos")]
[ApiController]
public class ProductoController : ControllerBase
{

    private readonly IProductoRepository _productoRepository;

    public ProductoController(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }


    [HttpGet]
    public async Task<ActionResult> GetAllProductos()
    {
        try
        {
            return Ok(await _productoRepository.GetAllProductos());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor al obtener los datos");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        try
        {
            var result = await _productoRepository.GetProducto(id);
            if (result == null) return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor al obtener los datos");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> CreateProducto(Producto producto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var createdProducto = await _productoRepository.CreateProducto(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = createdProducto.Id }, createdProducto);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor al crear el producto");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Producto>> UpdateProducto(int id, Producto inputProducto)
    {
        try
        {
            if (id != inputProducto.Id) return BadRequest("No coinciden los Id proporcionados");

            var productoToUpdate = await _productoRepository.GetProducto(id);

            if (productoToUpdate == null) return NotFound($"Producto con el Id = { id } no fue encontrado");

            return await _productoRepository.UpdateProducto(inputProducto, productoToUpdate);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor al actualizar el producto");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProducto(int id)
    {
        try
        {
            var productoToDelete = await _productoRepository.GetProducto(id);

            if ( productoToDelete == null ) return NotFound($"Tarea con el Id = { id } no existe");

            await _productoRepository.DeleteProducto(id);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error interno del servidor al eliminar el producto");
        }
    }
}