using Livescore.DataModel.LeagueModel;
using Livescore.Models.LivescoreModels.LeagueModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Livescore.Views.Leagues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectLeagues : ContentPage
    {
        //LivescoreRepository repository;

        public SelectLeagues()
        {
            InitializeComponent();
            this.BindingContext = new LivescoreRepository();
            //repository = new LivescoreRepository();
        }

        

        //public async Task<League> GetLeagues()
        //{
        //    var leagues = await repository.GetLeagues();

        //    if(leagues != null)
        //    {
        //        return leagues;
        //    }
        //    else
        //    {
        //        await DisplayAlert("League Info Exception", "Exception Thrown at GetLeagues", "OK");
        //        return null;
        //    }
        //}
    }
}