using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppDbFirstApproach.Models;

namespace WebAppDbFirstApproach.Data;

public class WebAppDbFirstApproachContext : IdentityDbContext<AppUser>
{
    public WebAppDbFirstApproachContext(DbContextOptions<WebAppDbFirstApproachContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> appUsers { get; set; }

    public DbSet<Category> tblcategories { get; set; }
    public DbSet<Product> tblproduct { get; set; }
    public DbSet<ProductImg> tblproductimg { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
