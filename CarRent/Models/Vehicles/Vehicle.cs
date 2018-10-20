namespace CarRent.Models.Vehicles
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string ModelSeries { get; set; }

        public string RegistrationCountry { get; set; }
        public int RegistrationYear { get; set; }
        public string RegistrationNumber { get; set; }

        public FuelType Fuel { get; set; }
        public TransmissionType Transmission { get; set; }
        public string FuelConsumption { get; set; }
    }
}
