using System.Collections.Generic;
using System.Linq;

namespace CarRent.Models.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _appDbContext;

        public VehicleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public object Vehicle => throw new System.NotImplementedException();

        public void AddVehicle(Vehicle vehicle)
        {
            _appDbContext.Vehicle.Add(vehicle);
        }

        public void DeleteVehicle(int vehicleId)
        {
            Vehicle vehicle = _appDbContext.Vehicle.Find(vehicleId);
            _appDbContext.Vehicle.Remove(vehicle);
        }

        public void EditVehicle(Vehicle vehicle)
        {
            _appDbContext.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _appDbContext.Vehicle;
        }

        public Vehicle GetVehicleByID(int vehicleId)
        {
            return _appDbContext.Vehicle.FirstOrDefault(v => v.ID == vehicleId);
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
