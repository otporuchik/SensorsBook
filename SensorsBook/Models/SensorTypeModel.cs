using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorTypeModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorType { get; set; }

        public SensorTypeModel() { }

        public SensorTypeModel(string SensorName, string SensorType)
        {
            this.SensorName = SensorName;
            this.SensorType = SensorType;
        }
    }
}
