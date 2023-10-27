using ChatbotCitasMedicas.ApiNetCore.DataModel;
using ChatbotCitasMedicas.ApiNetCore.Models.Dto;
using ChatbotCitasMedicas.ApiNetCore.Models.EfCore;
using ChatbotCitasMedicas.ApiNetCore.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ChatbotCitasMedicas.ApiNetCore.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ChatBotController : Controller
    {
        private readonly IDapper _dapper;
        private readonly CitasMedicasDbContext _db;
        private readonly IConfiguration _configuration;

        public ChatBotController(IDapper dapper, CitasMedicasDbContext db, IConfiguration configuration)
        {
            _dapper = dapper;
            _db = db;
            _configuration = configuration;
        }

        [HttpGet("Especialidad")]
        public List<Especialidad> GetEspecialidad()
        {
            return _db.Especialidad.ToList();
        }
        [HttpGet("Paciente/{dni}")]
        public CitaMedica GetPaciente(string dni)
        {
            var paciente = _db.CitaMedica.FirstOrDefault(a => a.DNI_PACIENTE == dni);
            return paciente;
        }
        [HttpGet("MisCitasMedicas/{dni}")]
        public List<CitasMedicasListado> GetMisCitasMedicas(string dni)
        {
            var res = _dapper.GetAllReqObj<CitasMedicasListado>("SP_LISTAR_CITAS_PROGRAMADAS_X_PACIENTE", new { dni },
                commandType: CommandType.StoredProcedure);
            return res;
        }
        //[HttpPost("ProgramarCita")]
        //public IActionResult PostProgramarCita(CitaMedica req)
        //{
        //    var res = _dapper.GetAllReqObj<dynamic>("SP_LISTAR_CITAS_PROGRAMADAS_X_PACIENTE", new { dni },
        //        commandType: CommandType.StoredProcedure);
        //    return Ok(res);
        //}
    }
}
