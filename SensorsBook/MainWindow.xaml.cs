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
using SensorsBook.ViewModels;
using SensorsBook.Models;

namespace SensorsBook
{
    public partial class MainWindow : Window
    {

        string sourcePath, targetPath, fileName, destFile;
        string[] files;

        public MainWindow()
        {
            InitializeComponent();

            //creating directories for images and docks if not existed
            sourcePath = @".\ImageFolder";
            DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);
            if (!dirInfo.Exists)
                dirInfo.Create();
            sourcePath = @".\DocksFolder";
            dirInfo = new DirectoryInfo(sourcePath);
            if (!dirInfo.Exists)
                dirInfo.Create();

            //copying all files (images) from sourcePath to targetPath
            sourcePath = @"C:\Users\HP\source\repos\SensorsBook\bin\Debug\net5.0-windows\ImageFolder";
            targetPath = @".\ImageFolder";

            files = System.IO.Directory.GetFiles(sourcePath);

            if (System.IO.Directory.Exists(sourcePath))
            {
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true); //true = if file exists it'll be overwritten.
                }
            }

            //creating DB if not existed
            if (!File.Exists("SensorsDB.db"))
            {
                System.Data.SQLite.SQLiteConnection.CreateFile(@".\SensorsDB.db");

                using (var db = new SQLite.SQLiteConnection("SensorsDB.db"))
                {
                    db.CreateTable<SensorTypeModel>();
                    db.CreateTable<SensorManufacturerModel>();
                    db.CreateTable<SensorImageModel>();
                    db.CreateTable<SensorCharacteristicModel>();
                    db.CreateTable<SensorModel>();
                }
            }
            
        }

        private void SensorsNameListButton_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SensorsNameListVM();
        }
    }
}
