using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotCitasMedicas.ApiNetCore.Models.EfCore
{
    [Table("TB_MEDICO", Schema = "dbo")]
    public class Medico
    {
        [Key]
        public string CODIGO_MEDICO { get; set; }
        public string NOMBRES_MEDICO { get; set; }
        public string ANIO_COLEGIADO { get; set; }
        public string CODIGO_DISTRITO { get; set; }
        public string CODIGO_ESPECIALIDAD { get; set; }
        public string CODIGO_HORARIO { get; set; }
        public string OCUPADO_MEDICO { get; set; }
    }
}
