using System;

namespace _Project.Services.AdsService
{
    public interface IAdsService
    {
        event Action RewardedVideoReady;
        bool IsRewardedVideoReady { get; }
        void Initialize();
        void ShowRewardedVideo(Action onVideoFinished);
    }
}