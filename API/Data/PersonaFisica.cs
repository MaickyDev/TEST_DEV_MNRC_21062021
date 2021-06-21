using API.Models;
using System.Linq;
using System.Collections.Generic;
using API.Models.Respuesta;

namespace API.Data
{
    public class PersonaFisica
    {
        public Respuesta<List<Tb_PersonasFisicas>> get()
        {
            var response = new Respuesta<List<Tb_PersonasFisicas>>();
            using (TokaEntities context = new TokaEntities())
            {
                var list = context.Tb_PersonasFisicas.Where(x => x.Activo == true).ToList();
                if (list == null)
                {
                    response.RespuestaError("No hay datos");
                    list = new List<Tb_PersonasFisicas>();
                }
                response.Entidad = list;
                return response;
            }
        }

        public Respuesta<Tb_PersonasFisicas> getById(int id)
        {
            var response = new Respuesta<Tb_PersonasFisicas>();
            using (TokaEntities context = new TokaEntities())
            {
                var item = context.Tb_PersonasFisicas.Where(x => x.IdPersonaFisica == id && x.Activo == true).FirstOrDefault();
                if (item == null)
                {
                    response.RespuestaError("No hay datos");
                    item = new Tb_PersonasFisicas();
                }
                response.Entidad = item;
                return response;
            }
        }

        public Respuesta add(Tb_PersonasFisicas model)
        {
            Respuesta response = new Respuesta();
            using (TokaEntities context = new TokaEntities())
            {
                var process = context.sp_AgregarPersonaFisica(
                    model.Nombre
                    , model.ApellidoMaterno
                    , model.ApellidoMaterno
                    , model.RFC
                    , model.FechaNacimiento
                    , model.UsuarioAgrega).FirstOrDefault();

                response.Codigo = (int)process.ERROR;
                response.Mensaje = process.MENSAJEERROR;
                return response;
            }
        }

        public Respuesta edit(Tb_PersonasFisicas model)
        {
            Respuesta response = new Respuesta();
            using (TokaEntities context = new TokaEntities())
            {
                var process = context.sp_ActualizarPersonaFisica(
                    model.IdPersonaFisica
                    , model.Nombre
                    , model.ApellidoMaterno
                    , model.ApellidoMaterno
                    , model.RFC
                    , model.FechaNacimiento
                    , model.UsuarioAgrega).FirstOrDefault();

                response.Codigo = (int)process.ERROR;
                response.Mensaje = process.MENSAJEERROR;
                return response;
            }
        }

        public Respuesta delete(int id)
        {
            Respuesta response = new Respuesta();
            using (TokaEntities context = new TokaEntities())
            {
                var process = context.sp_EliminarPersonaFisica(
                    id).FirstOrDefault();

                response.Codigo = (int)process.ERROR;
                response.Mensaje = process.MENSAJEERROR;
                return response;
            }
        }
    }
}