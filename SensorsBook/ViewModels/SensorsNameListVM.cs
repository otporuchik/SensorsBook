using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SensorsBook.Models;

namespace SensorsBook.ViewModels
{
    public class SensorsNameListVM
    {

        public List<SensorTypeModel> SensorTypes;
        public List<SensorTypeModel> SensorNames;

        public SensorsNameListVM()
        {
            using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
            {
                db.CreateTable<SensorTypeModel>();
            }
        }

        public List<SensorTypeModel> getTypesList()
        {
            using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
            {
                SensorTypes = db.Query<SensorTypeModel>
                    ("SELECT DISTINCT SensorType " +
                    "FROM SensorTypeModel");
            }

            return SensorTypes;
        }

        public List<SensorTypeModel> getNamesList(string Type)
        {
            using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
            {
                SensorNames = db.Query<SensorTypeModel>
                    ("SELECT SensorName " +
                    "FROM SensorTypeModel " +
                    $"WHERE SensorType = '{Type}'");
            }

            return SensorNames;
        }

    }
}
