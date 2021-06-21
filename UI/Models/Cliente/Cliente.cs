using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Cliente
{
    public class Clientes
    {
        public List<Cliente> Data { get; set; }
    }
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string FechaRegistroEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Sucursal { get; set; }
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int IdViaje { get; set; }
    }
}