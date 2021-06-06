using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorModel : ObservableObject
    {
        private string _sensorName;
        private string _sensorWebSite;
        private string _sensorDocksFolder;
        private string _sensorDescription;

        [PrimaryKey]
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

        public string SensorWebSite
        {
            get
            {
                if(string.IsNullOrEmpty(_sensorWebSite))
                    return "unknown sensor web site";
                return _sensorWebSite;
            }
            set
            {
                _sensorWebSite = value;
                OnPropertyChanged("SensorWebSite");
            }
        }

        public string SensorDocksFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorDocksFolder))
                    return "unknown sensor docks folder";
                return _sensorDocksFolder;
            }
            set
            {
                _sensorDocksFolder = value;
                OnPropertyChanged("SensorDocksFolder");
            }
        }

        public string SensorDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorDescription))
                    return "unknown sensor description";
                return _sensorDescription;
            }
            set
            {
                _sensorDescription = value;
                OnPropertyChanged("SensorDescription");
            }
        }
    }
}
