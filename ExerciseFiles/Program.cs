using ExerciseFiles.Entities;

namespace ExerciseFiles;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"/home/temp/products.csv";
        List<Product> products = new List<Product>();

        try
        {
            string[] lines = File.ReadAllLines(sourcePath);

            foreach (var line in lines)
            {
                string[] productData = line.Split(",");
                string productName = productData[0];
                double productPrice = double.Parse(productData[1]);
                int productQty = int.Parse(productData[2]);

                Product product = new Product(productName, productPrice, productQty);

                products.Add(product);
                double productTotalPrice = product.TotalPrice(product.Price, product.Quantity);

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