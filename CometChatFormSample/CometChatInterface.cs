using System;
namespace CometChatFormSample
{
    public interface CometChatInterface
    {
        void initializeCometChat(string SiteUrl,String LicenseKey, String ApiKey,Boolean isCometOnDemand,CometChatFormCallback callback);
        void loginWithUID(string UID, CometChatFormCallback callback);
        void launchCometChatWindow(Boolean isFullScreen, CometChatLaunchCallbacks launchCallbacks);
    }
}
