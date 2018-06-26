using System;
using System.Linq;
using CometChatFormSample;
using CometChatFormSample.iOS;
using cometchatui;
using MessageSDKFramework;
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
            cometchat = new CometChat();
            readyUI = new readyUIFIle();
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
                                    (dict) => { launchCallbacks.UserInfoCallback(dict.ToString()); },
                                    (dict1) => { launchCallbacks.ChatroomInfoCallback(dict1.ToString());  },
                                    (dict2) => { launchCallbacks.MessageReceiveCallback(dict2.ToString());  }, 
                                    (dict3) => { launchCallbacks.SuccessCallback(dict3.ToString()); }, 
                                    (err) => { launchCallbacks.FailCallback(err.ToString()); }, 
                                    (dict4) => { launchCallbacks.LogoutCallback(dict4.ToString());  }
                             );
        }

        public void loginWithUID(string UID, CometChatFormCallback callback)
        {
            cometchat.Login(UID, (dict) => { callback.SuccessCallback(dict.ToString());}, (err) => { callback.FailCallback(err.ToString()); /* code block */ });
        }
    }
}
