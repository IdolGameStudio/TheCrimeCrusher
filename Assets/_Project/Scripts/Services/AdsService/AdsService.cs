﻿using System;
using UnityEngine;

namespace _Project.Scripts.Services.AdsService
{
    public class AdsService : IAdsService
    {
        public event Action RewardedVideoReady;
        public bool IsRewardedVideoReady { get; }
        public void Initialize()
        {
            Debug.LogWarning("Initialization of ads service isn't implemented yet");
        }

        public void ShowRewardedVideo(Action onVideoFinished)
        {
            Debug.LogWarning("Showing of ads isn't implemented yet");
        }
    }
}