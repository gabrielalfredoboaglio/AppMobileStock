﻿using AppMobileStock.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileStock.Services
{
    public class ApiStockService
    {

        public HttpClient Client { get; set; }
        public string URL { get; set; }
        public string ErrorLog { get; set; }

        public ApiStockService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            this.Client = new HttpClient(httpClientHandler);
            this.URL = "https://192.168.0.185:45457/api/Stock/IngresarStock/";
        }

        public async Task<IngresoStockDTO> SendStock(IngresoStockDTO ingresoStockDTO)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    string url = this.URL;
                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    string content = JsonConvert.SerializeObject(ingresoStockDTO);

                    StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(url, body);

                    string data = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode)
                    {
                        if (data != null && data.Trim().StartsWith("{") && data.Trim().EndsWith("}"))
                        {
                            var datos = JsonConvert.DeserializeObject<IngresoStockDTO>(data);
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



        public async Task<EgresoStockDTO> SendEgresoStock(EgresoStockDTO EgresoStockDTO)
        {
            {
                try
                {
                    var httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        string url = "https://192.168.0.185:45457/api/Stock/EgresoStock";
                        client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                        string content = JsonConvert.SerializeObject(EgresoStockDTO);

                        StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                        var result = await client.PostAsync(url, body);

                        string data = await result.Content.ReadAsStringAsync();

                        if (result.IsSuccessStatusCode)
                        {
                            if (data != null && data.Trim().StartsWith("{") && data.Trim().EndsWith("}"))
                            {
                                var datos = JsonConvert.DeserializeObject<EgresoStockDTO>(data);
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
        }
    }
}