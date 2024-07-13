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
    }
}
