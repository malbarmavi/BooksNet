namespace BooksNet.Models
{
  public class BooksSearchData
  {
    public string Title { get; set; }

    public int Age { get; set; }

    public int Category { get; set; }

    public int[] Categories { get; set; }

    public int Publisher { get; set; }

    public int[] Authors { get; set; }

    public string Print { get; set; }

    public string PrintDate { get; set; }
  }
}