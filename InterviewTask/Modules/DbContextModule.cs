using InterviewTask.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewTask.Api.Modules
{
    public static class DbContextModule
    {
        public static void AddDbContextModule(this IServiceCollection services, IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(configuration["ConnectionStrings:InterviewTaskConnectionString"]))
            {
                throw new Exception("ConnectionStrings:InterviewTaskConnectionString cannot be empty in IConfiguration");
            }

            services.AddDbContext<InterviewTaskDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("InterviewTaskConnectionString"));
            });
        }
    }
    
}
