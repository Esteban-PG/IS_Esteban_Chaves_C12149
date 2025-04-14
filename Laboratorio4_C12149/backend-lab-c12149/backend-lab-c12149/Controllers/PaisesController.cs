using backend_lab_c12149.Handlers;
using backend_lab_c12149.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_c12149.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisesHandler;

        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }



        [HttpGet]
        public List<PaisesModel> Get() { 
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }
    }
}
