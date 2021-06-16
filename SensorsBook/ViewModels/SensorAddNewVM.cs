using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsBook.Models;

namespace SensorsBook.ViewModels
{
    class SensorAddNewVM : ObservableObject
    {
        private string _sensorName;
        private string _sensorWebSite;
        private string _sensorDocksFolder;
        private string _sensorDescription;
        private string _sensorType;
        private string _sensorManufacturer;

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
                if (string.IsNullOrEmpty(_sensorWebSite))
                    return "unknown web site";
                return _sensorWebSite;
            }
            set
            {
                _sensorWebSite = value;
                OnPropertyChanged(nameof(SensorWebSite)); //just to test nameof...
            }
        }
        public string SensorDocksFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_sensorDocksFolder))
                    return "unknown docks folder";
                return _sensorDocksFolder;
            }
            set
            {
                _sensorDocksFolder = value;
                OnPropertyChanged(nameof(SensorDocksFolder));
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
                OnPropertyChanged(nameof(SensorDescription));
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
                OnPropertyChanged(nameof(SensorType));
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
                OnPropertyChanged(nameof(SensorManufacturer));
            }

        }
        public ObservableCollection<SensorImageModel> SensorImages { get; set; }
        public ObservableCollection<SensorCharacteristicModel> SensorCharacteristics { get; set; }

        //for test

        public SensorAddNewVM()
        {
            SensorImages = new ObservableCollection<SensorImageModel>();
            SensorCharacteristics = new ObservableCollection<SensorCharacteristicModel>();
        }

    }
}
