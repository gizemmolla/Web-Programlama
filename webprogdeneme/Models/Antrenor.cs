namespace FitnessCenter.Models;
public class Antrenor
{
    public int Id { get; set; }
    public string AdSoyad { get; set; } = string.Empty;
    public string Uzmanlik { get; set; } = "Genel";
    public List<string> MusaitlikSaatleri { get; set; } = new(); // "2025-12-15 10:00" gibi
}
