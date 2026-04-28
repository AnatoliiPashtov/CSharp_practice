using Newtonsoft.Json;

namespace ConsoleApp15
{
  internal class Program
  {
    public class Movie
    {
      private string _name;
      private int[] _stars;
      public string Name => _name;
      public int[] Starts => _stars.ToArray();
      public Movie(string name)
      {
        _name = name;
        _stars = new int[0];
      }
      public void Add(int star)
      {
        Array.Resize(ref _stars, _stars.Length + 1);
        _stars[_stars.Length - 1] = star;
      }
    }

    static void Main(string[] args)
    {
      Movie m = new Movie("Star wars");
      m.Add(5);
      m.Add(2);
      m.Add(4);

      var temp = new
      {
        MovieType = m.GetType().Name,
        m.Name,
        m.Starts
      };

      string json = JsonConvert.SerializeObject(temp);
      Console.WriteLine(json);
      string forderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      string filePath = Path.Combine(forderPath, "movie.json");
      File.WriteAllText(filePath, json);

      string content = File.ReadAllText(filePath);
      var json2 = JsonConvert.DeserializeObject<dynamic>(content);
      Movie m2 = new Movie((string)json2.Name);
      foreach (var star in json2.Stars)
      {
        m2.Add((int)star);
      }

      //string forderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      //string filePath = Path.Combine(forderPath, "Test", "example.txt");
      //Console.WriteLine(forderPath);
      //Console.WriteLine(filePath);

      //string folderPathForFile = Path.GetDirectoryName(filePath);
      //if (Directory.Exists(folderPathForFile))
      //{
      //  Console.WriteLine("Directory already exists");
      //}
      //else
      //{
      //  Directory.CreateDirectory(folderPathForFile);
      //  Console.WriteLine("Directory create");
      //}

      //if (File.Exists(filePath))
      //{
      //  Console.WriteLine("File already exists");
      //}
      //else
      //{
      //  File.Create(filePath).Close();
      //  Console.WriteLine("File create");
      //}

      //File.WriteAllText(filePath, "Hello, world!");
      //File.WriteAllText(filePath, "Bye");
      //// Текст пустой создаст новый текст, не пустой перезапишит
      //string[] words = new string[] { "just", "another", "example" };
      //File.WriteAllLines(filePath, words);

      //File.AppendAllText(filePath, "kjdsfhk");
      //File.AppendAllText(filePath, "mzxcmnz");
      //File.AppendAllLines(filePath, words);

      //string content1 = File.ReadAllText(filePath);
      //Console.WriteLine(content1);
      //string[] content2 = File.ReadAllLines(filePath);
      //foreach (string word in words)
      //{
      //  Console.WriteLine(word);
      //}

      //File.Delete(filePath);
      //Directory.Delete(folderPathForFile);
    }
  }
}
