using Microsoft.EntityFrameworkCore;
using BTLNhapMonCNPM.Models;
using BTLNhapMonCNPM.Services;

namespace BTLNhapMonCNPM.Data;


public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Drink> Drinks => Set<Drink>();

    public DbSet<DrinkImage> DrinkImages => Set<DrinkImage>();

    public DbSet<Bill> Bills => Set<Bill>();

    public DbSet<BillDetail> BillDetails => Set<BillDetail>();

    public DbSet<Category> Categories => Set<Category>();

    public FileService FileService;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DrinkImage>()
            .HasOne(e => e.Drink)
            .WithMany(e => e.Images)
            .HasForeignKey(e => e.DrinkId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder.Entity<Bill>()
            .HasMany(e => e.Drinks)
            .WithMany(e => e.Bills)
            .UsingEntity<BillDetail>();

        modelBuilder.Entity<Drink>().
            HasOne(e => e.Category)
            .WithMany(e => e.Drinks)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Cà phê" },
            new Category { Id = 2, Name = "Freeze" },
            new Category { Id = 3, Name = "Trà" },
            new Category { Id = 4, Name = "Bánh" }
        );
    }
}