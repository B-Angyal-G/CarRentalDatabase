using Berauto.Models;
using Microsoft.EntityFrameworkCore;

namespace Berauto;

public class DbManager
{
    
    // HOZZÁADÁSOK

    public void AddClient(Client client)
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }
    }
    
    public void AddCar(Car car)
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }
    }
    
    public void AddAdmin(Admin admin)
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            db.Admins.Add(admin);
            db.SaveChanges();
        }
    }
    
    
    // AUTÓ LEKÉRDEZÉSEK

    public List<Car> GetAvailableCars()
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            return db.Cars
                .Include(c => c.Fuel)
                .Include(c => c.StatusId)
                .Where(c => c.StatusId == 1)
                .ToList();
        }
    }
    
    public List<Car> GetAvailablePetrolCars()
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            return db.Cars
                .Include(c => c.Fuel)
                .Include(c => c.StatusId)
                .Where(c => c.StatusId == 1 && c.FuelId == 1)
                .ToList();
        }
    }
    
    public List<Car> GetAvailableDieselCars()
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            return db.Cars
                .Include(c => c.Fuel)
                .Include(c => c.StatusId)
                .Where(c => c.StatusId == 1 && c.FuelId == 2)
                .ToList();
        }
    }
    
    public List<Car> GetRentedCars()
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            return db.Cars
                .Include(c => c.Fuel)
                .Include(c => c.StatusId)
                .Where(c => c.StatusId == 2)
                .ToList();
        }
    }
    
    public List<Car> GetServicedCars()
    {
        using (CarRentalDbContext db = new CarRentalDbContext())
        {
            return db.Cars
                .Include(c => c.Fuel)
                .Include(c => c.StatusId)
                .Where(c => c.StatusId == 3)
                .ToList();
        }
    }
}