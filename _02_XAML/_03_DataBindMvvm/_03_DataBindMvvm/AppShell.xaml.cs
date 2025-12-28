using _03_DataBindMvvm.Pages;

namespace _03_DataBindMvvm
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
