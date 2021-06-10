using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SensorsBook.Models
{
    public class SensorModel
    {
        [PrimaryKey]
        public string SensorName { get; set; }
        public string SensorWebSite { get; set; }
        public string SensorDocksFolder { get; set; }
        public string SensorDescription { get; set; }
    }
}
