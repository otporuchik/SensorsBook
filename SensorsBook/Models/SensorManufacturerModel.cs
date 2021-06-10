using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorManufacturerModel : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorManufacturer { get; set; }
    }
}
