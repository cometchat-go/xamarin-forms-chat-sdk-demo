using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CometChatFormSample
{
    public partial class MainPage : ContentPage
    {
        String siteurl = "";
        String licenseKey = "COMETCHAT-XXXXX-XXXXX-XXXXX-XXXXX"; // Replace the value with your CometChat License Key here
        String apiKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // Replace the value with your CometChat API Key here
        Boolean isCometOnDemand = true;
        private String UID1 = "SUPERHERO1";
        private String UID2 = "SUPERHERO2";
      
        public MainPage()
        {
            InitializeComponent();
        }
        void OnInitializeCometChat(object sender, EventArgs args)
        {
            System.Console.WriteLine("initializeCometChat ");
            var cometchat = DependencyService.Get<CometChatInterface>();

			cometchat.initializeCometChat(siteurl, licenseKey, apiKey, isCometOnDemand, new Callbacks(success => initializeSuccess(success), fail => initializeFail(fail)));

        }

        private void initializeSuccess(String success)
        {
            if (success != null)
            {
                System.Console.WriteLine("initializeSuccess " + success.ToString());
            }

        }
        private void initializeFail(String fail)
        {
            if (fail != null)
            {
                System.Console.WriteLine("initializeSuccess " + fail.ToString());
            }
        }


        void OnLoginSuperHero1(object sender, EventArgs args)
        {
            login(UID1);

        }
        void OnLoginSuperHero2(object sender, EventArgs args)
        {
            login(UID2);

        }
        void login(String UID)
        {
            System.Console.WriteLine("Hello " + UID);
            var cometchat = DependencyService.Get<CometChatInterface>();
            cometchat.loginWithUID(UID, new Callbacks(success => loginSuccess(success), fail => loginFail(fail)));

        }

        private void loginSuccess(string success)
        {
            if (success != null)
            {
                System.Console.WriteLine("loginSuccess " + success.ToString());
            }
        }

        private void loginFail(string fail)
        {
            if (fail != null)
            {
                System.Console.WriteLine("loginFail " + fail.ToString());
            }
        }

        void OnLaunchCometChat(object sender, EventArgs args)
        {
            
            var cometchat = DependencyService.Get<CometChatInterface>();
            cometchat.launchCometChatWindow(true, new LaunchCallbackImplementation(successObj => OnSuccessCall(successObj), fail => OnFailCall(fail), onChatroomInfo => OnChatroomInfo(onChatroomInfo), onError => OnError(onError), onLogout => OnLogout(onLogout), onMessageReceive => OnMessageReceive(onMessageReceive), onUserInfo => OnUserInfo(onUserInfo), onWindowClose => OnWindowClose(onWindowClose)));
        }

        private void OnSuccessCall(String successObj)
        {
            if (successObj != null)
            {
                System.Console.WriteLine("loginSuccess " + successObj.ToString());
            }
        }

        private void OnFailCall(String fail)
        {
            if (fail != null)
            {
                System.Console.WriteLine("OnFailCall " + fail.ToString());
            }
        }

        private void OnChatroomInfo(String onChatroomInfo)
        {
            if (onChatroomInfo != null)
            {
                System.Console.WriteLine("OnChatroomInfo " + onChatroomInfo.ToString());
            }
        }

        private void OnError(String onError)
        {
            if (onError != null)
            {
                System.Console.WriteLine("OnError " + onError.ToString());
            }
        }

        private void OnLogout(String onError)
        {
            if (onError != null)
            {
                System.Console.WriteLine("OnLogout " + onError.ToString());
            }
        }

        private void OnMessageReceive(String onMessageReceive)
        {
            if (onMessageReceive != null)
            {
                System.Console.WriteLine("OnMessageReceive " + onMessageReceive.ToString());
            }
        }

        private void OnUserInfo(String onUserInfo)
        {
            if (onUserInfo != null)
            {
                System.Console.WriteLine("OnUserInfo " + onUserInfo.ToString());

            }
        }

        private void OnWindowClose(String onWindowClose)
        {
            if (onWindowClose != null)
            {
                System.Console.WriteLine("OnWindowClose " + onWindowClose.ToString());
            }
        }
    }
}
