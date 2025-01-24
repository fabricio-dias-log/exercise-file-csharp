using System.Globalization;
using ExerciseFiles.Entities;

namespace ExerciseFiles;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"/home/fabricio/temp/exercise-files-csharp/products.csv";
        string targetPath = @"/home/fabricio/temp/exercise-files-csharp/out/";

        try
        {
            string[] lines = File.ReadAllLines(sourcePath);

            foreach (var line in lines)
            {
                string[] productData = line.Split(",");
                string productName = productData[0];
                double productPrice = double.Parse(productData[1], CultureInfo.InvariantCulture);
                int productQty = int.Parse(productData[2]);

                Product product = new Product(productName, productPrice, productQty);

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                string filePath = targetPath + "summary.csv";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(product.ToString());
                }
            }

        }
        catch (IOException e)
        {
            Console.WriteLine($"File error:{e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}