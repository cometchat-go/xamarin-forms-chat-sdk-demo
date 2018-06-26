using System;

namespace CometChatFormSample
{
    public interface CometChatFormCallback
    {
        void SuccessCallback(String username);
        void FailCallback(String jSONObject);
    }
}
