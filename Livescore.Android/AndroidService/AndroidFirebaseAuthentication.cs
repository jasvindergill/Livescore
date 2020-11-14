using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Content;
using Livescore.Services;

namespace Livescore.Droid.AndroidService
{
    public class AndroidFirebaseAuthentication //: IFirebaseAuthentication
    {
        //public Task<string> LoginWithEmailAndPassword()
        //{
        //    Context context = Android.App.Application.Context;
        //    GoogleSignInOptions gso;
        //    GoogleApiClient googleApiClient;
        //    try
        //    {
        //        gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
        //            .RequestIdToken("139244143339-vtobmksmjglfg78m63bfu4rdaqienta9.apps.googleusercontent.com")
        //            .RequestEmail().Build();

        //        googleApiClient = new GoogleApiClient.Builder(context)
        //            .AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();
        //        googleApiClient.Connect();

        //        var intent = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
        //        context.StartActivity(intent);

        //        string ss = string.Empty;
        //        return ss;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}