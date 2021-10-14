namespace Backend.Models
{
  public class Text
  {
    public string content { get; set; }
    public string mostCommonWord { get; set; }
    public int occurrences { get; set; }
  }
}