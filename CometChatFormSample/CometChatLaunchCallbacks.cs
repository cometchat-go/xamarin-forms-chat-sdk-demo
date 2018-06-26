using System;

namespace CometChatFormSample
{
    public interface CometChatLaunchCallbacks
    {
        void WindowCloseCallback(String onWindowClose);
        void UserInfoCallback(String onUserInfo);
        void MessageReceiveCallback(String onMessageReceive);
        void LogoutCallback(String onLogout);
        void ErrorCallback(String onError);
        void ChatroomInfoCallback(String onChatroomInfo);
        void FailCallback(String fail);
        void SuccessCallback(String successObj);
    }
}
