using System.Globalization;
using ExerciseFiles.Entities;

namespace ExerciseFiles;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter file full path: ");
        string sourceFilePath = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(sourceFilePath);
            string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
            string targetFolderPath = sourceFolderPath + @"/out";
            string targetFilePath = targetFolderPath + @"/summary.csv";

            if (!Directory.Exists(targetFolderPath))
            {
                Directory.CreateDirectory(targetFolderPath);
            }

            using (StreamWriter sw = File.AppendText(targetFilePath))
            {
                foreach (var line in lines)
                {
                    string[] productData = line.Split(",");
                    string productName = productData[0];
                    double productPrice = double.Parse(productData[1], CultureInfo.InvariantCulture);
                    int productQty = int.Parse(productData[2]);

                    Product product = new Product(productName, productPrice, productQty);

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