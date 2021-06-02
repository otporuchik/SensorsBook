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
        private string _sensorName;
        private string _sensorCharacteristicName;
        private string _sensorCharacteristicValue;

        [PrimaryKey]
        public int Id { get; set; }

        public string SensorName
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorName))
                    return "unknown sensor name";
                return _sensorName;
            }
            set
            {
                _sensorName = value;
                OnPropertyChanged("SensorName");
            }
        }

        public string SensorCharacteristicName
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorCharacteristicName))
                    return "unknown characteristic name";
                return _sensorCharacteristicName;
            }
            set
            {
                _sensorCharacteristicName = value;
                OnPropertyChanged("SensorCharacteristicName");
            }
        }

        public string SensorCharacteristicValue
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorCharacteristicValue))
                    return "unknown sensor characteristic value";
                return _sensorCharacteristicValue;
            }
        }
    }
}
