using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto
    {

        private readonly VentasContext _context;
        private ControlError Log = new ControlError();

        public ProductoServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetListaProductos(int productoID, decimal precio)
        {
            var respuesta = new Respuesta();
            try
            {
                if (productoID == 0 && precio == 0)
                {
                    //respuesta = await _context.Productos.ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from P in _context.Productos 
                                       join ma in _context.Marcas on P.MarcaId equals ma.MarcaId
                                       join c in _context.Categoria on P.CategId equals c.CategId
                                       join mo in _context.Modelos on P.ModeloId equals mo.ModeloId
                                       where P.Estado.Equals("A")
                                       select new ProductoDto
                                       {
                                           ProductoId = P.ProductoId,
                                           ProductoDescrip = P.ProductoDescrip,
                                           Estado = P.Estado,
                                           FechaHoraReg = P.FechaHoraReg,
                                           Precio = P.Precio,
                                           CategNombre = c.CategNombre,
                                           MarcaNombre = ma.MarcaNombre,
                                           ModeloDescripción = mo.ModeloDescripción
                                       }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }
                else if (productoID != 0 && precio == 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Estado.Equals("A")).ToListAsync();
                    //respuesta = await _context.Productos.ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from P in _context.Productos
                                            join ma in _context.Marcas on P.MarcaId equals ma.MarcaId
                                            join c in _context.Categoria on P.CategId equals c.CategId
                                            join mo in _context.Modelos on P.ModeloId equals mo.ModeloId
                                            where (P.Estado.Equals("A") && P.ProductoId.Equals(productoID))
                                            select new ProductoDto
                                            {
                                                ProductoId = P.ProductoId,
                                                ProductoDescrip = P.ProductoDescrip,
                                                Estado = P.Estado,
                                                FechaHoraReg = P.FechaHoraReg,
                                                Precio = P.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = ma.MarcaNombre,
                                                ModeloDescripción = mo.ModeloDescripción
                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }
                else if (precio != 0 && productoID == 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
                else if (precio != 0 && productoID != 0)
                {
                    respuesta.Data = await _context.Productos.Where(x => x.ProductoId.Equals(productoID) && x.Precio.Equals(precio) && x.Estado.Equals("A")).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "GetListaProductos", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostEjemplo(Ejemplo ejemplo)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ejemplos.Add(ejemplo);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "PostEjemplo", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefault();

                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "PutProducto", ex.Message);
            }
            return respuesta;
        }
    }
}
