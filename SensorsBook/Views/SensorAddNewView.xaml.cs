using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SensorsBook.Views
{
    /// <summary>
    /// Interaction logic for SensorAddNewView.xaml
    /// </summary>
    public partial class SensorAddNewView : UserControl
    {
        SensorImageModel selectedImage;
        int selectedCharacteristicIndex = -1;

        public SensorAddNewView()
        {
            InitializeComponent();
        }

        private void AddNewCharact_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                if(selectedCharacteristicIndex == -1) //that means there is no selected item to edit in characteristic list.
                {
                    addNewVM.SensorCharacteristics.Add(new SensorCharacteristicModel(addNewVM.SensorName, CharactName.Text, CharactValue.Text));
                }
                else
                {
                    SensorCharacteristicModel sensorCharacteristic = new SensorCharacteristicModel(addNewVM.SensorName, CharactName.Text, CharactValue.Text);
                    MessageBox.Show("I'm here");
                    addNewVM.SensorCharacteristics[selectedCharacteristicIndex] = sensorCharacteristic;
                    selectedCharacteristicIndex = -1;
                }
            }
        }

        private void RemoveCharact_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                if(addNewVM.SensorCharacteristics.Count > 0)
                {
                    addNewVM.SensorCharacteristics.Remove(addNewVM.SensorCharacteristics[addNewVM.SensorCharacteristics.Count - 1]);
                }
                else
                {
                    MessageBox.Show("Nothing to delete!");
                }
            }
        }

        private void addNewSensorType_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                //creating directory for images and docks if not existed
                //image dir
                string targetPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}ImageFolder\{addNewVM.SensorName}"; //getting running directory
                DirectoryInfo dirInfo = new DirectoryInfo(targetPath);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                //copying chosen images (findImage_clicked) to previously created directory in ImageFolder
                //and change sensor name in case it was changed after collection had been first time created.
                FileInfo fileInfo;
                foreach(SensorImageModel imageModel in addNewVM.SensorImages)
                {
                    fileInfo = new FileInfo(imageModel.SensorImageSource);
                    fileInfo.CopyTo($@"{targetPath}\{imageModel.SensorImageName}", true);
                    imageModel.SensorName = addNewVM.SensorName;
                }

                //dock dir
                targetPath = $@"{System.AppDomain.CurrentDomain.BaseDirectory}DocksFolder\{addNewVM.SensorName}";
                dirInfo = new DirectoryInfo(targetPath);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                //copying docks in to dock dir

                foreach(SensorDockumentModel dockModel in addNewVM.SensorDockuments)
                {
                    fileInfo = new FileInfo(dockModel.SensorDockumentSource);
                    fileInfo.CopyTo($@"{targetPath}\{dockModel.SensorDockumentName}", true);
                    dockModel.SensorName = addNewVM.SensorName;
                }

                using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
                {
                    //if sensor exists (edit of existing) delete it and then add edited like new
                    List<SensorTypeModel> sensor = db.Query<SensorTypeModel>($"SELECT * FROM SensorTypeModel WHERE SensorName = '{addNewVM.SensorName}'");
                    if(sensor != null)
                    {
                        db.Execute
                        ($"DELETE FROM SensorTypeModel WHERE SensorName = '{addNewVM.SensorName}'");
                        db.Execute
                            ($"DELETE FROM SensorManufacturerModel WHERE SensorName = '{addNewVM.SensorName}'");
                        db.Execute
                            ($"DELETE FROM SensorImageModel WHERE SensorName = '{addNewVM.SensorName}'");
                        db.Execute
                            ($"DELETE FROM SensorDockumentModel WHERE SensorName = '{addNewVM.SensorName}'");
                        db.Execute
                            ($"DELETE FROM SensorCharacteristicModel WHERE SensorName = '{addNewVM.SensorName}'");
                        db.Execute
                            ($"DELETE FROM SensorModel WHERE SensorName = '{addNewVM.SensorName}'");
                    }
                    //adding new sensor
                    db.Insert(new SensorModel(addNewVM.SensorName, addNewVM.SensorWebSite, addNewVM.SensorDescription));
                    db.Insert(new SensorTypeModel(addNewVM.SensorName, addNewVM.SensorType));
                    db.Insert( new SensorManufacturerModel(addNewVM.SensorName, addNewVM.SensorManufacturer));
                    db.InsertAll(addNewVM.SensorImages);
                    db.InsertAll(addNewVM.SensorDockuments);
                    db.InsertAll(addNewVM.SensorCharacteristics);
                }
            }
            MainWindow.GetWindow(this).DataContext = new SensorsNameListVM();
        }

        private void findImage_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Images (*.png)|*.png|All files(*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.ShowDialog();

            FileInfo eachFileInfo;
            foreach(string eachFile in openFileDialog.FileNames)
            {
                eachFileInfo = new FileInfo(eachFile);
                //only to show in preview, before writing to sql (addNewSensorType_clicked) need to be overwritten with current valuew in case they're newer.
                addNewVM.SensorImages.Add(new SensorImageModel(addNewVM.SensorName, eachFileInfo.Name, eachFileInfo.FullName));
            }
        }

        private void RemoveImage_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if (addNewVM != null)
            {
                if (addNewVM.SensorImages.Count > 0)
                {
                    addNewVM.SensorImages.Remove(addNewVM.SensorImages[addNewVM.SensorImages.Count - 1]);
                }
                else
                {
                    MessageBox.Show("Nothing to delete!");
                }
            }
        }

        //it's just a test of functionality
        private void hyperLink_clicked(object sender, RoutedEventArgs e)
        {
            //Process.Start("notepad.exe");
            if(selectedImage != null)
            {
                MessageBox.Show(selectedImage.SensorImageName);
            }
           else
            {
                MessageBox.Show("Nothing to show! Choose smth first!");
            }
        }

        private void findDock_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Dockuments (*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if(openFileDialog.ShowDialog() == true)
            {
                FileInfo eachFileInfo;
                foreach(string eachFile in openFileDialog.FileNames)
                {
                    eachFileInfo = new FileInfo(eachFile);
                    //only to show in preview, before writing to sql (addNewSensorType_clicked) need to be overwritten with current values in case they're newer
                    addNewVM.SensorDockuments.Add(new SensorDockumentModel(addNewVM.SensorName, eachFileInfo.Name, eachFileInfo.FullName));
                }
            }
        }

        private void RemoveDock_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                if(addNewVM.SensorDockuments.Count > 0)
                {
                    addNewVM.SensorDockuments.Remove(addNewVM.SensorDockuments[addNewVM.SensorDockuments.Count - 1]);
                }
                else
                {
                    MessageBox.Show("Nothing to delete!");
                }
            }
        }

        private void Image_selected(object sender, SelectionChangedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;

            selectedImage = (SensorImageModel)SensorImagesView.SelectedItem;
            MessageBox.Show($"{selectedImage.SensorImageName}\n{selectedImage.SensorImageSource}\n{SensorImagesView.SelectedIndex}");
        }

        private void SensorCharactItem_selected(object sender, SelectionChangedEventArgs e)
        {
            SensorCharacteristicModel sensorCharacteristic = (SensorCharacteristicModel)SensorCharacteristicsListView.SelectedItem;
            /*
            MessageBox.Show($"selected charact name = {sensorCharacteristic.SensorCharacteristicName}\n" +
                $"selected charact value = {sensorCharacteristic.SensorCharacteristicValue}\n" +
                $"selected charact index = {SensorCharacteristicsListView.SelectedIndex}");
            */

            selectedCharacteristicIndex = SensorCharacteristicsListView.SelectedIndex;

            if(sensorCharacteristic != null)
            {
                CharactName.Text = sensorCharacteristic.SensorCharacteristicName;
                CharactValue.Text = sensorCharacteristic.SensorCharacteristicValue;
            }
        }
    }
}
