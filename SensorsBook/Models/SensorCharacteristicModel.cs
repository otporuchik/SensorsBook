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
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorCharacteristicName { get; set; }
        public string SensorCharacteristicValue { get; set; }

        public SensorCharacteristicModel() { }

        public SensorCharacteristicModel(string SensorName, string SensorCharacteristicName, string SensorCharacteristicValue)
        {
            this.SensorName = SensorName;
            this.SensorCharacteristicName = SensorCharacteristicName;
            this.SensorCharacteristicValue = SensorCharacteristicValue;
        }
    }
}
