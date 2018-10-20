using CarRent.Models.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarRent.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: Vehicles
        public IActionResult Index()
        {
            var vehicles = from v in _vehicleRepository.GetAllVehicles()
                           select v;

            return View(vehicles.ToList());
        }

        //
        // GET: /Student/Details/5
        public ViewResult Details(int id)
        {
            Vehicle vehicle = _vehicleRepository.GetVehicleByID(id);
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,MakeName,ModelName,ModelSeries,RegistrationCountry,RegistrationYear,RegistrationNumber,Fuel,Transmission,FuelConsumption")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleRepository.AddVehicle(vehicle);
                _vehicleRepository.Save();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public IActionResult Edit(int id)
        {
            var vehicle = _vehicleRepository.GetVehicleByID(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,MakeName,ModelName,ModelSeries,RegistrationCountry,RegistrationYear,RegistrationNumber,Fuel,Transmission,FuelConsumption")] Vehicle vehicle)
        {
            if (id != vehicle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleRepository.EditVehicle(vehicle);
                    _vehicleRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public IActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Vehicle vehicle = _vehicleRepository.GetVehicleByID(id);
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _vehicleRepository.DeleteVehicle(id);
            _vehicleRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _vehicleRepository.Vehicle.Equals(id);
        }
    }
}
