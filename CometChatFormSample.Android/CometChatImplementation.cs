using System;
using Android.Content;
using CometChatFormSample;
using CometChatFormSample.Droid;
using Xamarin.Forms;
using Org.Json;
using Cometchat.Inscripts.Com.Cometchatcore.Coresdk;
using CometChatUIBinding.Additions;

[assembly: Dependency(typeof(CometChatImplementation))]
namespace CometChatFormSample.Droid
{
    public class CometChatImplementation : CometChatInterface
    {
        CometChat cometchat = null;
        public static Context context;
        public CometChatImplementation()
        {
        }

        public void initializeCometChat(string SiteUrl, string LicenseKey, string ApiKey, bool isCometOnDemand, CometChatFormCallback callback)
        {

            if (context != null)
            {
                cometchat = CometChat.GetInstance(context);
                cometchat.InitializeCometChat(SiteUrl, LicenseKey, ApiKey, isCometOnDemand, new CometChatCallback(success => callback.SuccessCallback((string)success), fail => callback.FailCallback((string)fail)));
            }
            else
            {
                System.Console.Write("Conetext Null");
            }
        }

        public void loginWithUID(string UID, CometChatFormCallback callback)
        {
            cometchat.LoginWithUID(context, UID, new CometChatCallback(success => callback.SuccessCallback((string)success), fail => callback.FailCallback((string)fail)));
        }

        public void launchCometChatWindow(bool isFullScreen, CometChatLaunchCallbacks launchCallbacks)
        {
            if (context != null)
            {
                cometchat.LaunchCometChat((Android.App.Activity)context, isFullScreen, new LaunchCallbacks(successObj => launchCallbacks.SuccessCallback((string)successObj), fail => launchCallbacks.FailCallback((string)fail), onChatroomInfo => launchCallbacks.ChatroomInfoCallback((string)onChatroomInfo), onError => launchCallbacks.ErrorCallback((string)onError), onLogout => launchCallbacks.LogoutCallback((string)onLogout), onMessageReceive => launchCallbacks.MessageReceiveCallback((string)onMessageReceive), onUserInfo => launchCallbacks.UserInfoCallback((string)onUserInfo), onWindowClose => launchCallbacks.WindowCloseCallback((string)onWindowClose)));
            }
            else
            {
                System.Console.Write("Conetext Null");
            }
        }

        public void launchCometChatWithId(bool isFullScreen, String userOrGroupId, bool isGroup, bool setBackButton, CometChatLaunchCallbacks launchCallbacks)
        {
            if (context != null)
            {
                cometchat.LaunchCometChat((Android.App.Activity)context, isFullScreen, userOrGroupId, isGroup, setBackButton, new LaunchCallbacks(successObj => launchCallbacks.SuccessCallback((string)successObj), fail => launchCallbacks.FailCallback((string)fail), onChatroomInfo => launchCallbacks.ChatroomInfoCallback((string)onChatroomInfo), onError => launchCallbacks.ErrorCallback((string)onError), onLogout => launchCallbacks.LogoutCallback((string)onLogout), onMessageReceive => launchCallbacks.MessageReceiveCallback((string)onMessageReceive), onUserInfo => launchCallbacks.UserInfoCallback((string)onUserInfo), onWindowClose => launchCallbacks.WindowCloseCallback((string)onWindowClose)));
            }
            else
            {
                System.Console.Write("Conetext Null");
            }
        }
    }

}


