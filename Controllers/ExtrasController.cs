using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {

        private ControlError Log = new ControlError();
        private PokeApi pokeApi = new PokeApi();

        private ChuckNorrisApi chuckNorrisApi = new ChuckNorrisApi();

        private readonly IConfiguration _configuration;

        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value;

                respuesta.Data = await pokeApi.GetPokeApi(url); //aqui llega el texto plano
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorris")]
        public async Task<Respuesta> GetChuckNorris()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlChuckNorrisApi").Value;

                respuesta.Data = await chuckNorrisApi.GetChuckNorrisApi(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ChuckNorrisApi", "GetChuckNorris", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisApiCategory")]
        public async Task<Respuesta> GetChuckNorrisApiCategory(string categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                if (categoria == null || categoria == "0")
                {
                    respuesta.Data = "Ingrese la información correcta a consultar.";
                }
                else if (categoria != null || categoria != "0")
                {
                    var urlSetting = _configuration.GetSection("Key:UrlChuckNorrisApiCategory").Value;
                    var parametro = categoria;
                    var url = urlSetting + parametro;
                    respuesta.Data = await chuckNorrisApi.GetChuckNorrisApiCategory(url);
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ChuckNorrisApi", "GetChuckNorrisApiCategory", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisApiRandom")]
        public async Task<Respuesta> GetChuckNorrisApiRandom()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Key:UrlChuckNorrisApiRandom").Value;

                respuesta.Data = await chuckNorrisApi.GetChuckNorrisApiRandom(url);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ChuckNorrisApi", "GetChuckNorrisApiRandom", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckNorrisApiTexto")]
        public async Task<Respuesta> GetChuckNorrisApiTexto(string texto)
        {
            var respuesta = new Respuesta();
            try
            {
                if (texto == null || texto == "0")
                {
                    respuesta.Data = "Ingrese la información correcta a consultar.";
                }
                else if (texto != null || texto != "0")
                {
                    var urlSetting = _configuration.GetSection("Key:UrlChuckNorrisApiTextoLibre").Value;
                    var parametro = texto;
                    var url = urlSetting + parametro;
                    respuesta.Data = await chuckNorrisApi.GetChuckNorrisApiTexto(url);
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("ChuckNorrisApi", "UrlChuckNorrisApiTextoLibre", ex.Message);
            }
            return respuesta;
        }
    }
}
