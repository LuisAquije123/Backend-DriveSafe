using _3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3.Data.Context;

public class DriveSafeDBContext : DbContext
{
    public DriveSafeDBContext(){}
    public DriveSafeDBContext(DbContextOptions<DriveSafeDBContext> options) : base(options) { }
    
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;pwd=Upc123!;Database=DriveSafe", //Aqui es DriveSafe
                serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Usuario>().ToTable("Usuarios");
    }
}