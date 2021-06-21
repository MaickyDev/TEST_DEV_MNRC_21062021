using System;
using API.Data;
using API.Models;
using System.Web.Http;

namespace API.Controllers.v1
{
    [RoutePrefix("api/v1/PersonaFisica")]
    public class PersonaFisicaController : ApiController
    {
        public PersonaFisica adminPersonaFifica = new PersonaFisica();

        [HttpGet]
        [Route("", Name = "GetList")]
        public IHttpActionResult GetList()
        {
            try
            {
                var response = adminPersonaFifica.get();
                return Ok(response);
            }
            catch (Exception ex)
            {
                //aqui se puede agregar algun loger ejemplo log4net
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var response = adminPersonaFifica.getById(id);
                    return Ok(response);
                }
                return BadRequest("No se pudo obtener la información, porfavor valide los datos");
            }
            catch (Exception ex)
            {
                //aqui se puede agregar algun loger ejemplo log4net
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("", Name = "Create")]
        public IHttpActionResult Create([FromBody] Tb_PersonasFisicas datos)
        {
            try
            {
                var response = adminPersonaFifica.add(datos);
                return Ok(response);
            }
            catch (Exception ex)
            {
                //aqui se puede agregar algun loger ejemplo log4net
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("", Name = "Edit")]
        public IHttpActionResult Edit([FromBody] Tb_PersonasFisicas datos)
        {
            try
            {
                if (ModelState.IsValid && datos.IdPersonaFisica > 0)
                {
                    var response = adminPersonaFifica.edit(datos);
                    return Ok(response);
                }
                return BadRequest("No se pudo completar la actualización, porfavor valide los datos");
            }
            catch (Exception ex)
            {
                //aqui se puede agregar algun loger ejemplo log4net
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id}", Name = "Delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if(id > 0)
                {
                    var response = adminPersonaFifica.delete(id);
                    return Ok(response);
                }
                return BadRequest("No se pudo completar la eliminación, porfavor valide los datos");
            }
            catch (Exception ex)
            {
                //aqui se puede agregar algun loger ejemplo log4net
                return InternalServerError(ex);
            }
        }
    }
}
