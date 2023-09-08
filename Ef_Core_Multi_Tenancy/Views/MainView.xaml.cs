using DevExpress.Xpf.Core;
using Ef_Core_Multi_Tenancy.ViewModels;

namespace Ef_Core_Multi_Tenancy.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : ThemedWindow
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;

            App.Current.MainWindow = this;
            ThemedWindow.RoundCorners = true;
        }
    }
}
