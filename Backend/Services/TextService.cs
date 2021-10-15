using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

    public static Text processFile(IFormFile file)
    {
      string content = ReadFromFile(file);
      string pattern = @"[^\wåäöÅÄÖ ]";
      string cleanedContent = Regex.Replace(content, pattern, "");
      string[] chunkOfWords = cleanedContent.Split(" ");
      Dictionary<string, int> wordWithCountDict = createDictionaryWithWordsAndOccurrences(chunkOfWords);
      int highestCount = getHighestOccurrence(wordWithCountDict);
      List<string> mostCommonWords = getMostCommonWordFromDict(wordWithCountDict, highestCount);
      string mostCommonWordsString = string.Join(", ", mostCommonWords.ToArray());
      string processedContent = populateTextWithFooBar(content, mostCommonWords);
      return new Text { content = processedContent, mostCommonWord = mostCommonWordsString, occurrences = highestCount };
    }

    private static Dictionary<string, int> createDictionaryWithWordsAndOccurrences(string[] words)
    {
      Dictionary<string, int> dict = new Dictionary<string, int>();
      foreach (string word in words)
      {
        if (dict.ContainsKey(word))
        {
          dict[word]++;
        }
        else
        {
          dict[word] = 1;
        }
      }

      //To remove empty space dict
      if (dict.ContainsKey(""))
      {
        dict.Remove("");
      }
      return dict;
    }

    private static int getHighestOccurrence(Dictionary<string, int> words)
    {
      int count = 0;
      foreach (string word in words.Keys)
      {
        if (words[word] >= count)
        {
          count = words[word];
        }
      }
      return count;
    }

    private static List<string> getMostCommonWordFromDict(Dictionary<string, int> words, int highestCount)
    {
      List<string> mostCommonWords = new List<string>();
      foreach (string word in words.Keys)
      {
        if (words[word] == highestCount)
        {
          mostCommonWords.Add(word);
        }
      }
      return mostCommonWords;
    }

    private static string ReadFromFile(IFormFile file)
    {
      Stream stream = file.OpenReadStream();
      StreamReader reader = new StreamReader(stream);
      string content = reader.ReadToEnd();
      return content;
    }

    private static string populateTextWithFooBar(string text, List<string> words)
    {
      string newText = text;
      foreach (string word in words)
      {
        string regex = string.Format(@"\b{0}\b", word);

        newText = Regex.Replace(text, regex, string.Format("foo{0}bar", word), RegexOptions.IgnoreCase);
      }
      return newText;
    }
  }
}