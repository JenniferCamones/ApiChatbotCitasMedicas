using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotCitasMedicas.ApiNetCore.Models.EfCore
{
    [Table("TB_ESPECIALIDAD", Schema = "dbo")]
    public class Especialidad
    {
        [Key]
        public string CODIGO_ESPECIALIDAD { get; set; }
        public string NOMBRE_ESPECIALIDAD { get; set; }
    }
}
