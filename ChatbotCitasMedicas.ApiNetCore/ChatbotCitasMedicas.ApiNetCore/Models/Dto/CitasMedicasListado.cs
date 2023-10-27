namespace ChatbotCitasMedicas.ApiNetCore.Models.Dto
{
    public class CitasMedicasListado
    {
        public string CODIGO_CITA { get; set; }
        public string NOMBRE_PACIENTE { get; set; }
        public string NOMBRES_MEDICO { get; set; }
        public string NOMBRE_ESPECIALIDAD { get; set; }
        public string TURNO { get; set; }
        public DateTime FECHA_CITA { get; set; }

    }
}
