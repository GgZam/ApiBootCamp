using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EjemploEntity.Services
{
    public class VentasServices : IVentas
    {
        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

        public VentasServices(VentasContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<VentasDto> query = (from v in _context.Ventas
                                               join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                               join p in _context.Productos on v.ProductoId equals p.ProductoId
                                               join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                               join ca in _context.Categoria on v.CategId equals ca.CategId
                                               join ma in _context.Marcas on v.MarcaId equals ma.MarcaId
                                               join su in _context.Sucursals on v.SucursalId equals su.SucursalId
                                               join cc in _context.Cajas on v.CajaId equals cc.CajaId
                                               join vv in _context.Vendedors on v.VendedorId equals vv.VendedorId
                                               select new VentasDto
                                               {
                                                   IdFactura = v.IdFactura,
                                                   NumFact = v.NumFact,
                                                   FechaHora = v.FechaHora,
                                                   ClienteId = cl.ClienteId,
                                                   ClienteNombre = cl.ClienteNombre,
                                                   ProductoNombre = p.ProductoDescrip,
                                                   ModeloNombre = mo.ModeloDescripción,
                                                   CategNombre = ca.CategNombre,
                                                   MarcaNombre = ma.MarcaNombre,
                                                   SucursalNombre = su.SucursalNombre,
                                                   CajaNombre = cc.CajaDescripcion,
                                                   VendedorId = v.VendedorId,
                                                   VendedorNombre = vv.VendedorDescripcion,
                                                   Precio = v.Precio,
                                                   Unidades = v.Unidades,
                                                   Estado = v.Estado
                                               });
                if (numFactura != null && numFactura != "0" && precio == 0 && vendedor == 0 && clienteId == 0)
                {
                    query = query.Where(n => n.NumFact == numFactura);
                }
                else if (numFactura != null && numFactura != "0" && precio != 0 && vendedor == 0 && clienteId == 0)
                {
                    query = query.Where(n => n.NumFact == numFactura && n.Precio == precio);
                }
                else if (precio != 0 && numFactura == null && numFactura == "0" && vendedor == 0 && clienteId == 0)
                {
                    query = query.Where(n => n.Precio == precio);
                }
                else if (vendedor != 0 && (numFactura == null || numFactura == "0") && precio == 0 && clienteId == 0)
                {
                    query = query.Where(n => n.VendedorId == vendedor);
                }
                else if (vendedor == 0 && (numFactura == null || numFactura == "0") && precio == 0 && clienteId != 0)
                {
                    query = query.Where(n => n.ClienteId == clienteId);
                }
                else if (clienteId != 0 && vendedor != 0 && (numFactura == null || numFactura == "0") && precio == 0)
                {
                    query = query.Where(n => n.ClienteId == clienteId && n.VendedorId == vendedor);
                }
                else if ((numFactura == null || numFactura == "0") && precio == 0 && vendedor == 0 && clienteId == 0)
                {
                    query = query.Where(n => n.NumFact == numFactura && n.Precio == precio && n.VendedorId == vendedor);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("VentasServices", "GetVentas", ee.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault();

                venta.IdFactura = Convert.ToInt32(query) + 1;
                venta.FechaHora = DateTime.Now;

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "999";
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("VentasServices", "PostVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("VentasServices", "PutVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Ventas.
                    Where(v => v.Precio > 100).
                    GroupBy(v => v.Precio).
                    Select(g => new
                    {
                        cant = g.Count(),
                        valor = g.Key
                    }).ToListAsync();
                respuesta.Mensaje = "ok";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("VentasServices", "GetVentaReporte", ee.Message);
            }
            return respuesta;
        }
    }
}
