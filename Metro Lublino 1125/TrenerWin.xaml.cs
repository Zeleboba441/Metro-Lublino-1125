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
    /// Interaction logic for TrenerWin.xaml
    /// </summary>
    public partial class TrenerWin : Window, INotifyPropertyChanged
    {
        private Trener selectedTrener;

        public Trener SelectedTrener
        {
            get => selectedTrener;
            set
            {
                selectedTrener = value;
                Signal();
            }
        }

        public ObservableCollection<Trener> Treners
        {
            get => Data.Treners;
        }
        public TrenerWin()
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

        private void AddTrener(object sender, RoutedEventArgs e)
        {
            Treners.Add(new Trener { LastName = "Фамилия" });
        }

        private void DeleteTrener(object sender, RoutedEventArgs e)
        {
            if (SelectedTrener == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранного тренера?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Treners.Remove(SelectedTrener);
            }

        }
    }

}
