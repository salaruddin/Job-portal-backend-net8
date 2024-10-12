using Job_portal_backend_net8.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Job_portal_backend_net8.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }


        //to configure model further, using fluent API, 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder is used to define relationships, keys, constraints
            modelBuilder.Entity<Job>()
                .HasOne(a => a.Company)
                .WithMany(company => company.Jobs)
                .HasForeignKey(a => a.CompanyId);

            modelBuilder.Entity<Candidate>()
                .HasOne(candidate => candidate.Job)
                .WithMany(job=>job.Candidates)
                .HasForeignKey(Candidate => Candidate.JobId);

            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();

            modelBuilder.Entity<Job>()
                .Property(job => job.Level)
                .HasConversion<string>();
            


        }
    }
}
