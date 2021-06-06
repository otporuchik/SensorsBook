using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorsBook.Models;

namespace SensorsBook.ViewModels
{
    public class SensorCardVM
    {
        public string SensorName { get; private set; }
        public string SensorWebSite { get; private set; }
        public string SensorDocksFolder { get; private set; }
        public string SensorDescription { get; private set; }
        public string SensorType { get; private set; }
        public string SensorManufacturer { get; set; }
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
