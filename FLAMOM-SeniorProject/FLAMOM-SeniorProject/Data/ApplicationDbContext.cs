using Microsoft.EntityFrameworkCore;

namespace FLAMOM_SeniorProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// This Constuctor enables us to pass connection string 
        /// from program.cs to the base class which is 
        /// the built in db context class
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        /// <summary>
        /// This method enables  additional configuration to the
        /// tables such as creating and inserting test data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        /// <summary>
        /// These dbset properties represent the tables and are required in order to migrate the tables to our sql server
        /// the package manager command line prompts are as follows
        /// add-migration <any Name goes here>
        /// to update the db and actually add the tables must use command
        /// update-database
        /// </summary>
        public DbSet<VisitInformation> VisitInformations { get; set; }
        public DbSet<ReasonForVisit> ReasonsForVisit { get; set; }
        public DbSet<HeardAbout> HeardAbouts { get; set; }
    }
}
