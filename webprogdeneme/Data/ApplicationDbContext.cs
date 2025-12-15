using FitnessCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Salon> Salonlar => Set<Salon>();
    public DbSet<Hizmet> Hizmetler => Set<Hizmet>();
    public DbSet<Antrenor> Antrenorler => Set<Antrenor>();
    public DbSet<Uye> Uyeler => Set<Uye>();
    public DbSet<Randevu> Randevular => Set<Randevu>();
}

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext db)
    {
        if (db.Salonlar.Any()) return;

        var salon = new Salon { Ad = "Merkez Şube", CalismaSaatleri = "08:00-22:00" };
        db.Salonlar.Add(salon);
        db.SaveChanges();

        var hizmet1 = new Hizmet { Ad = "Fitness", SureDakika = 60, Ucret = 250, SalonId = salon.Id };
        var hizmet2 = new Hizmet { Ad = "Yoga",    SureDakika = 45, Ucret = 200, SalonId = salon.Id };
        var hizmet3 = new Hizmet { Ad = "Pilates",    SureDakika = 60, Ucret = 300, SalonId = salon.Id };
        db.Hizmetler.AddRange(hizmet1, hizmet2, hizmet3);

        var ant1 = new Antrenor { AdSoyad = "Ayşe Koç", Uzmanlik = "Kilo verme", MusaitlikSaatleri = new() { "2025-12-15 10:00", "2025-12-15 11:00" } };
        var ant2 = new Antrenor { AdSoyad = "Emre Demir", Uzmanlik = "Kas geliştirme", MusaitlikSaatleri = new() { "2025-12-15 14:00" } };
        var ant3 = new Antrenor { AdSoyad = "Salih Kaya", Uzmanlik = "Kas geliştirme", MusaitlikSaatleri = new() { "2025-12-15 17:00" } };
        db.Antrenorler.AddRange(ant1, ant2, ant3);

        var uye = new Uye { AdSoyad = "Test Uye", Email = "test@example.com" };
        db.Uyeler.Add(uye);

        db.SaveChanges();

        db.Randevular.Add(new Randevu
        {
            UyeId = uye.Id, AntrenorId = ant1.Id, HizmetId = hizmet1.Id,
            Baslangic = DateTime.Parse("2025-12-15 10:00"), SureDakika = 60, Onaylandi = true
        });

        db.SaveChanges();
    }
}
