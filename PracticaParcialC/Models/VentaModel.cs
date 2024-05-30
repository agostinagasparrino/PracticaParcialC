using PracticaParcialC.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PracticaParcialC.Models
{
    public class VentaModel
    {
        public int IdVenta { get; set; }

        [Required(ErrorMessage = "¡El nombre es requerido!")]
        [StringLength(50, ErrorMessage = "¡El nombre no puede superar los 50 caracteres!")]
        [RegularExpression("[a-zA-ZñÑáÁéÉíÍóÓúÚüÜ ]+", ErrorMessage = "¡El nombre solo puede contener letras y espacios!")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "¡La cantidad vendida es requerida!")]
        [Range(1, 300, ErrorMessage = "¡La cantidad vendida debe estar entre 1 y 300!")]
        public int CantidadVendida { get; set; }

        [Required(ErrorMessage = "¡El precio unitario es requerido!")]
        [Range(10, 1000, ErrorMessage = "¡El precio unitario debe estar entre 10 y 1000!")]
        public int PrecioUnitario { get; set; }
        public int TotalVenta { get; set; }

        public VentaModel()
        {

        }

        public VentaModel(Venta venta)
        {
            IdVenta = venta.IdVenta;
            Cliente = venta.Cliente;
            CantidadVendida = venta.CantidadVendida;
            PrecioUnitario = venta.PrecioUnitario;
            TotalVenta = venta.TotalVenta;
        }

        public static List<VentaModel> MapearAListaModel(List<Venta> ventas)
        {
            return ventas.Select(v => new VentaModel(v)).ToList();
        }

        public Venta MapearAEntidad()
        {
            return new Venta
            {
                IdVenta = IdVenta,
                Cliente = Cliente,
                CantidadVendida = CantidadVendida,
                PrecioUnitario = PrecioUnitario,
                TotalVenta = TotalVenta
            };
        }

    }
}
