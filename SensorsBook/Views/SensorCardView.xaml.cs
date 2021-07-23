using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SensorsBook.Models;
using SensorsBook.ViewModels;


namespace SensorsBook.Views
{

    public partial class SensorCardView : UserControl
    {

        public SensorCardView()
        {
            InitializeComponent();
        }

        private void DeleteSensor_clicked(object sender, RoutedEventArgs e)
        {
            SensorCardVM SensorCard = this.DataContext as SensorCardVM;
            if(SensorCard != null)
            {
                MessageBox.Show($"You want to delete: {SensorCard.SensorName}");

                using (var db = new SQLite.SQLiteConnection("SensorsDB.db"))
                {
                    db.Execute
                        ($"DELETE FROM SensorTypeModel WHERE SensorName = '{SensorCard.SensorName}'");
                    db.Execute
                        ($"DELETE FROM SensorManufacturerModel WHERE SensorName = '{SensorCard.SensorName}'");
                    db.Execute
                        ($"DELETE FROM SensorImageModel WHERE SensorName = '{SensorCard.SensorName}'");
                    db.Execute
                        ($"DELETE FROM SensorDockumentModel WHERE SensorName = '{SensorCard.SensorName}'");
                    db.Execute
                        ($"DELETE FROM SensorCharacteristicModel WHERE SensorName = '{SensorCard.SensorName}'");
                    db.Execute
                        ($"DELETE FROM SensorModel WHERE SensorName = '{SensorCard.SensorName}'");
                }

                //deleting docks and image directories

                //image dir
                string targetPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}ImageFolder\{SensorCard.SensorName}"; //getting running directory
                DirectoryInfo dirInfo = new DirectoryInfo(targetPath);
                if (dirInfo.Exists)
                    dirInfo.Delete(true);//delete directory and all it's subdirectories and files in it

                //dock dir
                targetPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}DocksFolder\{SensorCard.SensorName}";
                dirInfo = new DirectoryInfo(targetPath);
                if (dirInfo.Exists)
                    dirInfo.Delete(true);
            }

            MainWindow.GetWindow(this).DataContext = new SensorsNameListVM();

        }

        //sending Sensor name to editors view
        private void EditSensor_clicked(object sender, RoutedEventArgs e)
        {
            SensorCardVM SensorCard = this.DataContext as SensorCardVM;
            MessageBox.Show($"{ SensorCard.SensorName} you want to edit");
            MainWindow.GetWindow(this).DataContext = new SensorAddNewVM(SensorCard.SensorName);
        }
    }
}
