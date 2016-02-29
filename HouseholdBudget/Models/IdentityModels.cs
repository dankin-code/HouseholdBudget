using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace HouseholdBudget.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HouseholdId { get; set; }
        public virtual Household Household { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AzureConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Household> Household { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        //public virtual DbSet<CategoryHousehold> CategoryHousehold { get; set; }
        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<BudgetItems> BudgetItems { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.Dashboard> Dashboards { get; set; }

        //public System.Data.Entity.DbSet<HouseholdBudget.Models.ApplicationUser> ApplicationUsers { get; set; }
        //public virtual DbSet<DashboardViewModel> DashboardViewModel { get; set; }

    }
}