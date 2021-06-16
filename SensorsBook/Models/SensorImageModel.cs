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
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorImageName { get; set; }
        public string SensorImageSource { get; set; }

        public SensorImageModel() { }

        public SensorImageModel(string SensorName, string SensorImageName, string SensorImageSource)
        {
            this.SensorName = SensorName;
            this.SensorImageName = SensorImageName;
            this.SensorImageSource = SensorImageSource;
        }
    }
}
