using Microsoft.EntityFrameworkCore;

namespace BackendService.Models
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
