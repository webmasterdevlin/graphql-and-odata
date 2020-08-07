using System.Collections.Generic;
using System.Collections.ObjectModel;
using TheGameShop.MobileApp.Models;
using TheGameShop.MobileApp.Services;
using Xamarin.Forms;

namespace TheGameShop.MobileApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Game> _games;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var games = await GraphQLServices.GetGames();

            _games = new ObservableCollection<Game>(games);

            GamesListView.ItemsSource = _games;

            base.OnAppearing();
        }
    }
}