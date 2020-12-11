using PicturePicker.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicturePicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}