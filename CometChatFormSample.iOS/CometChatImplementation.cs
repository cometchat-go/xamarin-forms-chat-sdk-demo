using System;
using System.Linq;
using CometChatBinding;
using CometChatFormSample;
using CometChatFormSample.iOS;
using CometChatUI;
using Firebase.Auth;
using Firebase.Database;
using Foundation;
using Plugin.FirebasePushNotification;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: Dependency(typeof(CometChatImplementation))]
namespace CometChatFormSample.iOS
{
    public class CometChatImplementation : CometChatInterface
    {
        CometChat cometchat = null;
        readyUIFIle readyUI = null;
        public CometChatImplementation()
        {
        }


        public void initializeCometChat(string SiteUrl, string LicenseKey, string ApiKey, bool isCometOnDemand, CometChatFormCallback callback)
        {
            System.Console.WriteLine("initializeCometChat CometChatImplementation");
            cometchat = new CometChat();
            readyUI = new readyUIFIle();
            User user = Auth.DefaultInstance.CurrentUser;
            Database database = Database.DefaultInstance;
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {


            };
            cometchat.InitializeCometChat(SiteUrl, LicenseKey, ApiKey, isCometOnDemand, (dictionary) => { if (dictionary != null) { callback.SuccessCallback(dictionary.ToString()); } }, (error) => { if (error != null) { callback.FailCallback(error.ToString()); } });
     
        }

        public void launchCometChatWindow(bool isFullScreen, CometChatLaunchCallbacks launchCallbacks)
        {
           //get current UIViewController
           var window = UIApplication.SharedApplication.KeyWindow;
            var currentView = window.RootViewController;
            while (currentView.PresentedViewController != null)
                currentView = currentView.PresentedViewController;

            var navController = currentView as UINavigationController;
            if (navController != null)
                currentView = navController.ViewControllers.Last();
            
            readyUI.LaunchCometChat(true, currentView,
                                    (dict) => {
                                        Console.WriteLine("OnUserInfo CometChatImplementation" + dict.ToString());
                                        String push_channel = (dict["push_channel"] as NSString);
                                        Console.WriteLine("push_channel " + push_channel);
                                        CrossFirebasePushNotification.Current.Subscribe(push_channel);
                                        launchCallbacks.UserInfoCallback(dict.ToString()); 
                            },
                                    (dict1) => { launchCallbacks.ChatroomInfoCallback(dict1.ToString());  },
                                    (dict2) => { launchCallbacks.MessageReceiveCallback(dict2.ToString());  }, 
                                    (dict3) => { launchCallbacks.SuccessCallback(dict3.ToString()); }, 
                                    (err) => { launchCallbacks.FailCallback(err.ToString()); }, 
                                    (dict4) => { launchCallbacks.LogoutCallback(dict4.ToString());  }
                             );
        }

        public void loginWithUID(string UID, CometChatFormCallback callback)
        {
            cometchat.LoginWithUID(UID, (dict) => { callback.SuccessCallback(dict.ToString());}, (err) => { callback.FailCallback(err.ToString()); /* code block */ });
        }
    }
}
