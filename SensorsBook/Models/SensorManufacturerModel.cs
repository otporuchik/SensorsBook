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
        private string _sensorName;
        private string _sensorManufacturer;

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

        public string SensorManufacturer
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorManufacturer))
                    return "unknown sensor manufacturer";
                return _sensorManufacturer;
            }
            set
            {
                _sensorManufacturer = value;
                OnPropertyChanged("SensorManufacturer");
            }
        }
    }
}
