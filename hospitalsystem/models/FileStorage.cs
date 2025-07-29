using System.Text.Json;

namespace hospitalsystem.models
{
    public static class FileStorage
    {
        public static void SaveToFile<T>(string fileName, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        public static List<T> LoadFromFile<T>(string fileName)
        {
            if (!File.Exists(fileName)) return new List<T>();
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        // ✅ Specific loaders
        public static List<Doctor> LoadDoctors()
        {
            return LoadFromFile<Doctor>("doctors.json");
        }

        public static List<Patient> LoadPatients()
        {
            return LoadFromFile<Patient>("patients.json");
        }

        public static List<Booking> LoadBookings()
        {
            return LoadFromFile<Booking>("bookings.json");
        }
    }
}
