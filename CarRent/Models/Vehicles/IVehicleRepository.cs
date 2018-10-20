using System.Collections.Generic;

namespace CarRent.Models.Vehicles
{
    public interface IVehicleRepository
    {
        object Vehicle { get; }

        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetVehicleByID(int vehicleId);
        void AddVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleId);
        void EditVehicle(Vehicle vehicle);
        void Save();
    }
}
