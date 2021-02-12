
using Loja.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        // GET: api/Clientes
        public IHttpActionResult Get()
        {

            try
            {
                return Ok(new Cliente().GetAll());
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        // GET: api/Clientes/5
        public IHttpActionResult Get(int id)
        {
            Cliente _return = new Cliente(id);
            if (_return.Codigo == 0)
            {             
                return NotFound();
            } else

            return Ok(_return);
            
        }

        // POST: api/Clientes
        public IHttpActionResult Post([FromBody]Cliente value)
        {
            try
            {
                value.Insert();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        // PUT: api/Clientes/5
        public IHttpActionResult Put(int id, [FromBody]Cliente value)
        {
            Cliente cli = new Cliente(id);
            cli.Codigo = value.Codigo;
            cli.Nome = value.Nome;
            cli.DataCadastro = value.DataCadastro;
            cli.Tipo = value.Tipo;

            try
            {
                cli.Update();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }

        // DELETE: api/Clientes/5
        public IHttpActionResult Delete(int id)
        {
            Cliente cli = new Cliente(id);

            try
            {
                cli.Delete();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
