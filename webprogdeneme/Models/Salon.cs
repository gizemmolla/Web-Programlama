namespace FitnessCenter.Models;
public class Salon
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string CalismaSaatleri { get; set; } = "09:00-21:00";
    public List<Hizmet> Hizmetler { get; set; } = new();
}
