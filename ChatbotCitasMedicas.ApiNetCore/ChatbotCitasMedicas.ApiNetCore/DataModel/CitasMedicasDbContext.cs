using ChatbotCitasMedicas.ApiNetCore.Models.EfCore;
using Microsoft.EntityFrameworkCore;

namespace ChatbotCitasMedicas.ApiNetCore.DataModel
{
    public partial class CitasMedicasDbContext : DbContext
    {
        public CitasMedicasDbContext()
        {
        }
        public CitasMedicasDbContext(DbContextOptions<CitasMedicasDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<CitaMedica> CitaMedica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Especialidad>();
            modelBuilder.Entity<Medico>();
            modelBuilder.Entity<CitaMedica>();
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
