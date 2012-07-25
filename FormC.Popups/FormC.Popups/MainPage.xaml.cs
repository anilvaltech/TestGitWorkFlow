using System.Windows.Controls;
using FormC.Popups.ViewModel;

namespace FormC.Popups
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            var mainVm = new MainViewModel();
            InitializeComponent();
            this.DataContext = mainVm;
        }
    }
}
