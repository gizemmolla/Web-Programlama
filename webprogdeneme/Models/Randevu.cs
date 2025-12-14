namespace FitnessCenter.Models;
public class Randevu
{
    public int Id { get; set; }
    public int UyeId { get; set; }
    public int AntrenorId { get; set; }
    public int HizmetId { get; set; }
    public DateTime Baslangic { get; set; }
    public int SureDakika { get; set; }
    public bool Onaylandi { get; set; }
}
