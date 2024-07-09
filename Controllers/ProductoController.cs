using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;
        private ControlError Log = new ControlError();

        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<Respuesta> GetListaProductos(int productoID, decimal precio)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID, precio);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "GetListaProductos", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostProducto", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostEjemplo")]
        public async Task<Respuesta> PostEjemplo([FromBody] Ejemplo ejemplo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PostEjemplo(ejemplo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PostEjemplo", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PutProducto([FromBody] Producto producto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ProductoController", "PutProducto", ex.Message);
            }
            return respuesta;
        }

    }
}
