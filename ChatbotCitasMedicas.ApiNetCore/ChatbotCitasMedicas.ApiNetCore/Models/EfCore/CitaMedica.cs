using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotCitasMedicas.ApiNetCore.Models.EfCore
{
    [Table("TB_PROGRAMAR_CITA", Schema = "dbo")]
    //hola
    public class CitaMedica
    {
        [Key]
        public int CODIGO_CITA { get; set; }
        public string CODIGO_MEDICO { get; set; }
        public string CODIGO_ESPECIALIDAD { get; set; }
        public string CODIGO_TURNO { get; set; }
        public string NOMBRE_PACIENTE { get; set; }
        public DateTime FECHA_CITA { get; set; }
        public string DNI_PACIENTE { get; set; }
    }
}
