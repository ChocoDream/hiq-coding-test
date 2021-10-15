using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

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

    public static void processFile(IFormFile file)
    {

    }

    private static string ReadFromFile(IFormFile file)
    {
      Stream stream = file.OpenReadStream();
      StreamReader reader = new StreamReader(stream);
      string content = reader.ReadToEnd();
      return content;
    }
  }
}