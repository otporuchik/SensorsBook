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

namespace SensorsBook.Views
{
    public partial class SensorsNameListView : UserControl
    {

        public List<SensorTypeModel> SensorTypes;
        public List<SensorTypeModel> SensorNames;

        public SensorsNameListView()
        {
            InitializeComponent();

            SensorTypeListView.ItemsSource = new SensorsNameListVM().getTypesList();
        }
    
        private void SensorType_selected(object sender, SelectionChangedEventArgs e)
        {
            SensorTypeModel _selectionType = (SensorTypeModel)SensorTypeListView.SelectedItem;
            if(_selectionType != null)
            {
                SensorNameListView.ItemsSource = new SensorsNameListVM().getNamesList(_selectionType.SensorType);
            }
        }

        private void SensorName_selected(object sender, SelectionChangedEventArgs e)
        {
            SensorTypeModel _selectionName = (SensorTypeModel)SensorNameListView.SelectedItem;
            if(_selectionName != null)
            {
                //MessageBox.Show($"Your choise is: {_selectionName.SensorName}");
                MainWindow.GetWindow(this).DataContext = new SensorCardVM(_selectionName.SensorName);
            }
        }
    }
}
