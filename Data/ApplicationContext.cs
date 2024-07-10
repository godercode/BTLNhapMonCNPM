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
    }
}