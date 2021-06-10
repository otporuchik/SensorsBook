using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorCharacteristicModel : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorCharacteristicName { get; set; }
        public string SensorCharacteristicValue { get; set; }
    }
}
