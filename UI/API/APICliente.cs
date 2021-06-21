using ClosedXML.Excel;
using Newtonsoft.Json;
using SpreadsheetLight;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using UI.Models.Cliente;

namespace UI.API
{
    public class APICliente
    {
        public string urlAPI = System.Configuration.ConfigurationManager.AppSettings["urlTokaAPICustomer"];
        public string urlAPILogin = System.Configuration.ConfigurationManager.AppSettings["urlTokaAPILogin"];
        public string endpoint = "customers";

        public string getTokenToka()
        {
            Token token = null;
            LoginCredentials credentials = new LoginCredentials() 
            {
                UserName = System.Configuration.ConfigurationManager.AppSettings["userName"],
                Password = System.Configuration.ConfigurationManager.AppSettings["password"]
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPILogin);
                var response = client.PostAsync("authenticate", new StringContent(JsonConvert.SerializeObject(credentials), Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    token = JsonConvert.DeserializeObject<Token>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return token.Data;
        }

        public List<Cliente> get(string token)
        {
            var data = new Clientes();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = client.GetAsync(endpoint).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    data = JsonConvert.DeserializeObject<Clientes>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            return data.Data.OrderBy(x => x.Nombre).ToList();
        }

        public MemoryStream generateExcel(int page, string token)
        {
            //string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path + "ListaClientes.xlsx";
            SLDocument excel = new SLDocument();
            System.Data.DataTable dt = new System.Data.DataTable("Grid");

            dt.Columns.Add("Fecha Registro Empresa", typeof(string));
            dt.Columns.Add("Razon Social", typeof(string));
            dt.Columns.Add("RFC", typeof(string));
            dt.Columns.Add("Sucursal", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Paterno", typeof(string));
            dt.Columns.Add("Materno", typeof(string));

            var list = get(token);
            list = list.Skip((page - 1) * 20).Take(20).ToList();
            foreach (var item in list)
            {
                dt.Rows.Add(item.FechaRegistroEmpresa, item.RazonSocial, item.RFC, item.Sucursal, item.Nombre, item.Paterno, item.Materno);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return stream;
                }
            }
        }
    }
}