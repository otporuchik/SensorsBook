using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorTypeModel : ObservableObject
    {
        private string _sensorName;
        private string _sensorType;

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

        public string SensorType
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorType))
                    return "unknown sensor type";
                return _sensorType;
            }
            set
            {
                _sensorType = value;
                OnPropertyChanged("SensorType");
            }
        }
    }
}
