using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : Controller
    {
        private readonly IVentas _ventas;
        private ControlError Log = new ControlError();

        public VentasController(IVentas ventas)
        {
            this._ventas = ventas;
        }

        [HttpGet]
        [Route("GetVentas")]
        public async Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.GetVentas(numFactura, precio, vendedor, clienteId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "GetVentas", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostVenta")]
        public async Task<Respuesta> PostVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.PostVenta(venta);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentasController", "PostVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutVenta")]
        public async Task<Respuesta> PutVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.PutVenta(venta);
            }
            catch (Exception ee)
            {
                Log.LogErrorMetodos("VentasController", "PutVenta", ee.Message);
            }
            return respuesta;
        }


        [HttpGet]
        [Route("GetVentaReporte")]
        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.GetVentaReporte();
            }
            catch (Exception ee)
            {
                Log.LogErrorMetodos("VentasController", "GetVentaReporte", ee.Message);
            }
            return respuesta;
        }
    }
}
