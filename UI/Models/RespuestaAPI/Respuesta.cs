using System;

namespace UI.Models.RespuestaAPI
{
    public class Respuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }

        public Respuesta()
        {
            Codigo = 0;
            Mensaje = null;
        }

        public void RespuestaError(string mensaje)
        {
            this.Codigo = -5000;
            this.Mensaje = mensaje;
        }
    }

    public class Respuesta<T> : Respuesta
    {
        public T Entidad { get; set; }

    }
}