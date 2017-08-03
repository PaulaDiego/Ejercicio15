using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

using Ejercicio15.Services;

namespace Ejercicio15.Controllers
{
    public class EntradasController : ApiController
    {
        
        private IEntradasService EntradasService;
        public EntradasController(IEntradasService _EntradasService)
        {
            this.EntradasService = _EntradasService;
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return EntradasService.ReadEntradas();
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = this.EntradasService.GetEntrada(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }

            try
            {
                this.EntradasService.PutEntrada(entrada);
            }
            catch (NoEncontradoException)
            {
                 return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entrada = this.EntradasService.Create(entrada);
            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada = this.EntradasService.GetEntrada(id);
            if (entrada == null)
            {
                return NotFound();
            }

            this.EntradasService.Delete(entrada);

            return Ok(entrada);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntradaExists(long id)
        {
            return this.EntradasService.ReadEntradas().Count(e => e.Id == id) > 0;
        }
    }
}