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

        [Ignore]
        public SensorTypeModel SensorType { get; set; }
        [Ignore]
        public SensorManufacturerModel SensorManufacturer { get; set; }
        [Ignore]
        public List<SensorImageModel> SensorImages { get; set; }
        [Ignore]
        public List<SensorCharacteristicModel> SensorCharacteristics { get; set; }

        public SensorModel() { }

        public SensorModel(string SensorName)
        {
            this.SensorName = SensorName;

            using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
            {
                this.SensorWebSite = db.ExecuteScalar<SensorModel>
                    ("SELECT SensorWebSite FROM SensorModel " +
                    $"WHERE SensorName = '{SensorName}").ToString();

                this.SensorDocksFolder = db.ExecuteScalar<SensorModel>
                    ("SELECT SensorDocksFolder FROM SensorModel " +
                    $"WHERE SensorName = '{SensorName}").ToString();

                this.SensorDescription = db.ExecuteScalar<SensorModel>
                    ("SELECT SensorDescription FROM SensorModel " +
                    $"WHERE SensorName = '{SensorName}").ToString();

                this.SensorType.SensorType = db.ExecuteScalar<SensorTypeModel>
                    ("SELECT SensorType FROM SensorType " +
                    $"WHERE SensorName = '{SensorName}'").ToString();

                this.SensorManufacturer.SensorManufacturer = db.ExecuteScalar<SensorManufacturerModel>
                    ("SELECT SensorManufacturer FROM SensorManufacturerModel " +
                    $"WHERE SensorName = '{SensorName}'").ToString();

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
