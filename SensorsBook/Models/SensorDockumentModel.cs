using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsBook.Models
{
    public class SensorDockumentModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorDockumentName { get; set; }
        public string SensorDockumentSource { get; set; }

        public SensorDockumentModel() { }

        public SensorDockumentModel(string SensorName, string SensorDockumentName, string SensorDockumentSource)
        {
            this.SensorName = SensorName;
            this.SensorDockumentName = SensorDockumentName;
            this.SensorDockumentSource = SensorDockumentSource;
        }
    }
}
