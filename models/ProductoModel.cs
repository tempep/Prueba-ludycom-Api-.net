using System.ComponentModel.DataAnnotations;

public class Producto {
    public int Id { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres")]
    public string Nombre { get; set; }

    [Required]
    public decimal Precio { get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage = "La descipción no puede exceder los 100 caracteres")]
    public string Descripcion {get; set; }
}