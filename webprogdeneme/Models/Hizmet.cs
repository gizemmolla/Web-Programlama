namespace FitnessCenter.Models;
public class Hizmet
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty; // Fitness, Yoga, Pilates...
    public int SureDakika { get; set; }
    public decimal Ucret { get; set; }
    public int SalonId { get; set; }
    public int AntrenorId {get; set; }
}
