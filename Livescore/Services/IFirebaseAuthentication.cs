using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Services
{
    public interface IFirebaseAuthentication
    {
        
        Task<string> LoginWithEmailAndPassword();

        //bool SignOut();

        //bool IsSignIn();
    }
}
