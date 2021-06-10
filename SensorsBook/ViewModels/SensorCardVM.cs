using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsBook.Models;

namespace SensorsBook.ViewModels
{
    public class SensorCardVM : ObservableObject
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
        public List<SensorImageModel> SensorImages { get; set; }
        public List<SensorCharacteristicModel> SensorCharacteristics { get; set; }


        //SensorsNameListView calling this constructor when particular sensor selected
        public SensorCardVM(string name)
        {
            this.SensorName = name;
            using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
            {
                db.CreateTable<SensorModel>();
                db.CreateTable<SensorTypeModel>();
                db.CreateTable<SensorManufacturerModel>();
                db.CreateTable<SensorImageModel>();
                db.CreateTable<SensorCharacteristicModel>();

                this.SensorWebSite = db.Query<SensorModel>
                    ("SELECT SensorWebSite FROM SensorModel " +
                    $"WHERE SensorName = '{name}'")[0].SensorWebSite;

                this.SensorDocksFolder = db.Query<SensorModel>
                    ("SELECT SensorDocksFolder FROM SensorModel " +
                    $"WHERE SensorName = '{SensorName}'")[0].SensorDocksFolder;

                this.SensorDescription = db.Query<SensorModel>
                    ("SELECT SensorDescription FROM SensorModel " +
                    $"WHERE SensorName = '{SensorName}'")[0].SensorDescription;

                this.SensorType = db.Query<SensorTypeModel>
                    ("SELECT SensorType FROM SensorTypeModel " +
                    $"WHERE SensorName = '{SensorName}'")[0].SensorType; 

                this.SensorManufacturer = db.Query<SensorManufacturerModel>
                    ("SELECT SensorManufacturer FROM SensorManufacturerModel " +
                    $"WHERE SensorName = '{SensorName}'")[0].SensorManufacturer; 

                this.SensorImages = db.Query<SensorImageModel>
                    ("SELECT * FROM SensorImageModel " +
                    $"WHERE SensorName = '{SensorName}'");

                this.SensorCharacteristics = db.Query<SensorCharacteristicModel>
                    ("SELECT * FROM SensorCharacteristicModel " +
                    $"WHERE SensorName = '{SensorName}'");
            }

        }
    }
}
