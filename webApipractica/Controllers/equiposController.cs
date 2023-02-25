using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApipractica.Models;
using Microsoft.EntityFrameworkCore;

namespace webApipractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContexto;
        
        public equiposController(equiposContext equiposContexto)
        {
            _equiposContexto = equiposContexto;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<equipos> listadoEquipo =(from e in _equiposContexto.equipos
                                           select e).ToList();
            if(listadoEquipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEquipo);
        }
        //localhost:7889/api/equipos/getbyid?id=3
       // localhost:7889/api/equipos/getbyid/3/
        [HttpGet]
        [Route ("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            equipos? equipo = (from e in _equiposContexto.equipos
                          where e.id_equipos == id
                          select e).FirstOrDefault();
            if (equipo == null) return NotFound();

            return Ok(equipo);
        }
        [HttpGet]
        [Route("find/{filtro}")]
        public IActionResult GetByName(string filtro)
        {
              List<equipos> equipo = (from e in _equiposContexto.equipos
                          where e.nombre.Contains(filtro)
                          select e).ToList();
            if (equipo == null) return NotFound();

            return Ok(equipo);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Post([FromBody]equipos equipo)
        {
            try
            {

            }catch( Exception ex)
            {
                return BadRequest(e)
            }
        }

    }
}
