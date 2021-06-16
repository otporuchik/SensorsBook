﻿using System;
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

namespace SensorsBook.Views
{
    /// <summary>
    /// Interaction logic for SensorAddNewView.xaml
    /// </summary>
    public partial class SensorAddNewView : UserControl
    {
        public SensorAddNewView()
        {
            InitializeComponent();
        }

        private void AddNewCharact_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                addNewVM.SensorCharacteristics.Add(new SensorCharacteristicModel(addNewVM.SensorName, CharactName.Text, CharactValue.Text));
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

        private void AddNewImage_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                addNewVM.SensorImages.Add(new SensorImageModel(addNewVM.SensorName, ImageName.Text, ImageSource.Text));
            }
        }

        private void RemoveImage_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
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

        private void addNewSensorType_clicked(object sender, RoutedEventArgs e)
        {
            SensorAddNewVM addNewVM = this.DataContext as SensorAddNewVM;
            if(addNewVM != null)
            {
                using (var db = new SQLite.SQLiteConnection("SensorsDB.db", true))
                {
                    db.CreateTable<SensorModel>();
                    db.Insert(new SensorModel(addNewVM.SensorName, addNewVM.SensorWebSite, addNewVM.SensorDocksFolder, addNewVM.SensorDescription));

                    db.CreateTable<SensorTypeModel>();
                    db.Insert(new SensorTypeModel(addNewVM.SensorName, addNewVM.SensorType));

                    db.CreateTable<SensorManufacturerModel>();
                    db.Insert( new SensorManufacturerModel(addNewVM.SensorName, addNewVM.SensorManufacturer));

                    db.CreateTable<SensorImageModel>();
                    db.InsertAll(addNewVM.SensorImages);

                    db.CreateTable<SensorCharacteristicModel>();
                    db.InsertAll(addNewVM.SensorCharacteristics);
                }
            }
        }
    }
}
