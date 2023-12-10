using InterviewTask.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask.Data
{
    public class InterviewTaskDbContext : DbContext
    {
        public InterviewTaskDbContext(DbContextOptions<InterviewTaskDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
