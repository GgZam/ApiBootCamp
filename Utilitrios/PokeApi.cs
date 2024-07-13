using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitrios
{
    public class PokeApi
    {
        private ControlError log = new ControlError();


        public async Task< Respuesta> GetPokeApi(string url)
        {
            var respuesta = new Respuesta();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data =JsonConvert.DeserializeObject<PokeApiDto>(json);
                respuesta.Mensaje = "Se consumio correctamente";

            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
    }
}
