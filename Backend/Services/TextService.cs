using Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Services
{
  public static class TextService
  {
    static Text text { get; set; }
    static TextService()
    {
      text = new Text { content = "lorem lipsum lipsum", mostCommonWord = "lipsum", occurrences = 2 };
    }

    public static Text Get() => text;
    public static void Post(Text newText)
    {
      text = newText;
    }
  }
}