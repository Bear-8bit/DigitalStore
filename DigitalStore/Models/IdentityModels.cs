using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using DigitalStore.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DigitalStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
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
            : base("ChuoiKN", throwIfV1Schema: false)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameImage> GameImages { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<GameNews> GameNews { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}