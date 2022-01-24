using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metro_Lublino_1125
{
    /// <summary>
    /// Interaction logic for SportWin.xaml
    /// </summary>
    public partial class SportWin : Window, INotifyPropertyChanged
    {
        private Sport selectedSport;

        public Sport SelectedSport
        {
            get => selectedSport;
            set
            {
                selectedSport = value;
                Signal();
            }
        }

        public ObservableCollection<Sport> Sports
        {
            get => Data.Sports;
        }
        public SportWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddSport(object sender, RoutedEventArgs e)
        {
            Sports.Add(new Sport { Name = "Название" });
        }

        private void DeleteSport(object sender, RoutedEventArgs e)
        {
            if (SelectedSport == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный спорт?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Sports.Remove(SelectedSport);
            }
        }
    }
}


    
