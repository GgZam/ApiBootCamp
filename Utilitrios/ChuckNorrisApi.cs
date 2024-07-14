using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitrios
{
    public class ChuckNorrisApi
    {
        private ControlError log = new ControlError();

        public async Task<Respuesta> GetChuckNorrisApi(string url)
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
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrusApi", "GetChuckNorrisApi", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetChuckNorrisApiCategory(string url)
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
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisCategoryDto>(json);
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrusApi", "GetChuckNorrisApiCategory", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetChuckNorrisApiRandom(string url)
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
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisRandom>(json);
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrusApi", "GetChuckNorrisApiRandom", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetChuckNorrisApiTexto(string url)
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
                respuesta.Data = JsonConvert.DeserializeObject<ChuckNorrisQuery>(json);
                respuesta.Mensaje = "Se consumio correctamente";
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ChuckNorrusApi", "GetChuckNorrisApiTexto", ex.Message);
            }
            return respuesta;
        }
    }
}
