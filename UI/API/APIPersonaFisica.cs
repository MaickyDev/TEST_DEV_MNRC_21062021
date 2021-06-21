using System;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using UI.Models.RespuestaAPI;
using UI.Models.PersonaFisica;
using System.Collections.Generic;

namespace UI.API
{
    public class APIPersonaFisica
    {
        public string urlAPI = System.Configuration.ConfigurationManager.AppSettings["urlAPI"];
        public string endpoint = "PersonaFisica";
        public Respuesta<List<PersonaFisica>> get()
        {
            var process = new Respuesta<List<PersonaFisica>>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    process = JsonConvert.DeserializeObject<Respuesta<List<PersonaFisica>>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return process;
        }

        public Respuesta<PersonaFisica> getById(int id)
        {
            var process = new Respuesta<PersonaFisica>();
            endpoint = string.Format("{0}/{1}", endpoint, id);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    process = JsonConvert.DeserializeObject<Respuesta<PersonaFisica>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return process;
        }

        public Respuesta add(PersonaFisica datos)
        {
            var process = new Respuesta();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var response = client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    process = JsonConvert.DeserializeObject<Respuesta>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return process;
        }

        public Respuesta edit(PersonaFisica datos)
        {
            var process = new Respuesta();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var response = client.PutAsync(endpoint, new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    process = JsonConvert.DeserializeObject<Respuesta>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return process;
        }

        public Respuesta delete(int id)
        {
            var process = new Respuesta();
            endpoint = string.Format("{0}/{1}", endpoint, id);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                var response = client.DeleteAsync(endpoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    process = JsonConvert.DeserializeObject<Respuesta>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return process;
        }
    }
}