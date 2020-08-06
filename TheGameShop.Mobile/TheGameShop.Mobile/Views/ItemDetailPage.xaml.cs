using System.ComponentModel;
using Xamarin.Forms;
using TheGameShop.Mobile.ViewModels;

namespace TheGameShop.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}