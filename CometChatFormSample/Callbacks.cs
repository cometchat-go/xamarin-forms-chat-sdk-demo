using System;

namespace CometChatFormSample
{
    public class Callbacks : CometChatFormCallback
    {

        Action<String> _onSuccess;
        Action<String> _onFail;

        public Callbacks(Action<String> onSuccess, Action<String> onFail)
        {
            this._onFail = onFail;
            this._onSuccess = onSuccess;
                
        }
        public void FailCallback(String p0)
        {
            this._onFail?.Invoke(p0);
        }

        public void SuccessCallback(String p0)
        {
            this._onSuccess?.Invoke(p0);
        }
    }
}
