using CarRent.Models.Vehicles;
using System.Collections.Generic;

namespace CarRent.ViewModels
{
    public class VehicleViewModel
    {
        public string Title { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
