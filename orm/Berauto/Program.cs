using System.Threading.Channels;
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


            Console.WriteLine();
            List<User> clients = manager.GetClients();
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }
    }
}

