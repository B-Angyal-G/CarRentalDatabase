using Berauto.Models;

namespace Berauto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbManager manager = new DbManager();

            List<Car> availableCars = manager.GetAvailableCars();
            foreach (var acars in availableCars)
            {
                Console.WriteLine(acars);
            }
        }
    }
}

