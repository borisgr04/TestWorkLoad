using Microsoft.EntityFrameworkCore;

namespace TestWorkLoad
{
    public class DbContextTest : DbContext 
    {
        public DbSet<Category> Category { get;set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:mi-asc-ecp-dev-mainsqlmidev.public.c105ff79c574.database.windows.net,3342; Authentication=Active Directory Default; Database=dbaeuecpdevtrue;MultipleActiveResultSets=False;Encrypt=True;Connection Timeout=30;");
        }

        
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(schema: "Admin");

        }
    }
}
