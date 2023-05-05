using AppMobileStock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileStock.Services
{
    public class ApiDepositoService
    {
        public HttpClient Client { get; set; }
        public string URL { get; set; }
        public string ErrorLog { get; set; }

        public ApiDepositoService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            this.Client = new HttpClient(httpClientHandler);
            this.URL = "https://192.168.0.185:45457/api/Deposito";
        }

        public async Task<DepositoDTO> SendDeposito(DepositoDTO depositoDTO)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    string url = this.URL;
                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    string content = JsonConvert.SerializeObject(depositoDTO);

                    StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(url, body);

                    string data = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {
                        if (data != null && data.Trim().StartsWith("{") && data.Trim().EndsWith("}"))
                        {
                            var datos = JsonConvert.DeserializeObject<DepositoDTO>(data);
                            return datos;
                        }
                        else
                        {
                            ErrorLog = "El JSON recibido no es válido";
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ErrorLog = $"Error de solicitud HTTP: {ex.Message}. Detalles: {ex.InnerException?.Message}";
                return null;
            }
            catch (JsonReaderException ex)
            {
                ErrorLog = $"Error al leer el JSON: {ex.Message}";
                return null;
            }
            catch (JsonSerializationException ex)
            {
                ErrorLog = $"Error al serializar/deserializar JSON: {ex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                ErrorLog = $"Error desconocido: {ex.Message}";
                return null;
            }
        }

        public async Task<List<DepositoDTO>> GetDepositos()
        {
            try
            {

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    string url = $"{this.URL}";

                    ErrorLog += $"Inicio Get order con url {url}";

                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    HttpResponseMessage response = await client.GetAsync(url);

                    ErrorLog += $"Hice gET aSYNC";

                    string data = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {

                        ErrorLog += $"Recibi data";
                        var datos = JsonConvert.DeserializeObject<List<DepositoDTO>>(data);
                        return datos;
                    }
                    else
                    {
                        ErrorLog += $"Recibi Errpr";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog += $"Error ejecutando get {ex.Message}";
                return null;

            }
        }
        public async Task<DepositoDTO> GetDepositoById(int id)
        {
            try
            {

                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    string url = $"{this.URL}/{id}";

                    ErrorLog += $"Inicio Get order con url {url}";

                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    HttpResponseMessage response = await client.GetAsync(url);

                    ErrorLog += $"Hice gET aSYNC";

                    string data = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {

                        ErrorLog += $"Recibi data";
                        var datos = JsonConvert.DeserializeObject<DepositoDTO>(data);
                        return datos;
                    }
                    else
                    {
                        ErrorLog += $"Recibi Errpr";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog += $"Error ejecutando get {ex.Message}";
                return null;

            }


        }
    }
}

