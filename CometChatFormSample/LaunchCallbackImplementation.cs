using System;

namespace CometChatFormSample
{
    public class LaunchCallbackImplementation : CometChatLaunchCallbacks
    {
        Action<String> _onSuccess;
        Action<String> _onFail;
        Action<String> _onChatroomInfo;
        Action<String> _onError;
        Action<String> _onLogout;
        Action<String> _onMessageReceive;
        Action<String> _onUserInfo;
        Action<String> _onWindowClose;
        Action<String> p1;
        Action<String> p2;

        public LaunchCallbackImplementation(Action<String> onSuccess, Action<String> onFail, Action<String> onChatroomInfo, Action<String> onError, Action<String> onLogout, Action<String> onMessageReceive, Action<String> onUserInfo, Action<String> onWindowClose)
        {
            this._onFail = onFail;
            this._onSuccess = onSuccess;
            this._onChatroomInfo = onChatroomInfo;
            this._onError = onError;
            this._onLogout = onLogout;
            this._onMessageReceive = onMessageReceive;
            this._onUserInfo = onUserInfo;
            this._onWindowClose = onWindowClose;
        }



        public void FailCallback(String p0)
        {
            this._onFail?.Invoke(p0);
        }

        public void SuccessCallback(String p0)
        {
            this._onSuccess?.Invoke(p0);
        }

        public void ChatroomInfoCallback(String p0)
        {
            this._onChatroomInfo?.Invoke(p0);
        }

        public void ErrorCallback(String p0)
        {
            this._onError?.Invoke(p0);
        }
        public void LogoutCallback(String p0)
        {
            this._onLogout?.Invoke(p0);

        }

        public void MessageReceiveCallback(String p0)
        {
            this._onMessageReceive?.Invoke(p0);
        }

        public void UserInfoCallback(String p0)
        {
            this._onUserInfo?.Invoke(p0);
        }

        public void WindowCloseCallback(String p0)
        {
            this._onWindowClose?.Invoke(p0);
        }


    }
}
