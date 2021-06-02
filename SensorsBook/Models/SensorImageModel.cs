using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorImageModel : ObservableObject
    {
        string _sensorName;
        string _sensorImageName;
        string _sensorImageSource;

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

        public string SensorImageName
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorImageName))
                    return "unknown sensor image name";
                return _sensorImageName;
            }
            set
            {
                _sensorImageName = value;
                OnPropertyChanged("SensorImageName");
            }
        }

        public string SensorImageSource
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorImageSource))
                    return "unknown image source";
                return _sensorImageSource;
            }
            set
            {
                _sensorImageSource = value;
                OnPropertyChanged("SensorImageSource");
            }
        }
    }
}
