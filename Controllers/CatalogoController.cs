using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCategoria();
            }
            catch (Exception ee)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCategoria", ee.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetMarca")]
        public async Task<Respuesta> GetMarca()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetMarca();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMarca")]
        public async Task<Respuesta> PostMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostMarca(marca);
            }
            catch (Exception ee)
            {
                Log.LogErrorMetodos("CatalogoController", "PostMarca", ee.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMarca")]
        public async Task<Respuesta> PutMarca([FromBody] Marca marca)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutMarca(marca);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetModelo")]
        public async Task<Respuesta> GetModelo()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModelo();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostModelo")]
        public async Task<Respuesta> PostModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModelo(modelo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody] Modelo modelo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModelo(modelo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCaja")]
        public async Task<Respuesta> GetCaja()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCaja();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCaja", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCaja")]
        public async Task<Respuesta> PostCaja([FromBody] Caja caja)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCaja(caja);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCaja", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetCiudad();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCiudad", ex.Message);
            }
            return respuesta;
        }
    }
}
