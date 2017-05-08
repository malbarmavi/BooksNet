using System.Drawing;
using System.Drawing.Imaging;

namespace BooksNet.Helper
{
  public class OptimizeImages
  {
    public static void SetCompressionLevel(Bitmap image, string path)
    {
      ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
      Encoder myEncoder = Encoder.Quality;
      EncoderParameters myEncoderParameters = new EncoderParameters(1);
      EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
      myEncoderParameters.Param[0] = myEncoderParameter;

      image.Save(path, jpgEncoder, myEncoderParameters);
    }

    private static ImageCodecInfo GetEncoder(ImageFormat format)
    {
      ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
      foreach (ImageCodecInfo codec in codecs)
      {
        if (codec.FormatID == format.Guid)
        {
          return codec;
        }
      }
      return null;
    }
  }
}