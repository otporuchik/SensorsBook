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
        [PrimaryKey]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string SensorImageName { get; set; }
        public string SensorImageSource { get; set; }
    }
}
