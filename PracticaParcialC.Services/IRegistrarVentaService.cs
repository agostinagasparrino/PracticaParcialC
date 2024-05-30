using PracticaParcialC.Entidades;

namespace PracticaParcialC.Services
{
    public interface IRegistrarVentaService
    {
        void RegistrarVenta(Venta venta);
        List<Venta> ObtenerVentas();
    }
    public class RegistrarVentaService : IRegistrarVentaService
    {
        private static List<Venta> _ventas = new List<Venta>();

        public void RegistrarVenta(Venta venta)
        {
            venta.TotalVenta = venta.CantidadVendida * venta.PrecioUnitario;
            venta.IdVenta = _ventas.Count == 0
                            ? 1 :
                            _ventas.Max(v => v.IdVenta) + 1;

            _ventas.Add(venta);
        }

        public List<Venta> ObtenerVentas()
        {
            return _ventas
                .OrderBy(v => v.IdVenta)
                .ToList();
        }
    }
}
