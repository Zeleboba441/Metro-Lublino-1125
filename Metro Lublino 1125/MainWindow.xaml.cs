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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metro_Lublino_1125
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Person selectedPerson;

        public ObservableCollection<Person> Persons
        {
            get => Data.Persons;
        }
        public ObservableCollection<Sport> Sports
        {
            get => Data.Sports;
        }

        public ObservableCollection<Trener> Treners
        {
            get => Data.Treners;
        }


        public Person SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                Signal();
            }
        }

        public MainWindow()
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

        private void AddPerson(object sender, RoutedEventArgs e)
        {
            Persons.Add(new Person
            {
                LastName = "Новый пипл",
                Data = DateTime.Today
            });
        }

        private void DeletePerson(object sender, RoutedEventArgs e)
        {

            if (SelectedPerson == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного пипла?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Persons.Remove(SelectedPerson);
                SelectedPerson = null;
            }
        }

        private void OpenSports(object sender, RoutedEventArgs e)
        {
            SportWin win = new SportWin();
            win.ShowDialog();

        }

        private void OpenTreners(object sender, RoutedEventArgs e)
        {
            TrenerWin win = new TrenerWin();
            win.ShowDialog();

        }

       
    }
}
    
