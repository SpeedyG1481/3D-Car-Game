using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class RewardedGoTo10
{
    private RewardedAd _rewarded;

    private string androidAdId = "ca-app-pub-8847668020520840/2041938623";
    private string iOSAdId = "ca-app-pub-8847668020520840/8328338895";

    public void Initialize(EventHandler<Reward> onReward)
    {
        MobileAds.Initialize(x =>
        {
            var adId = iOSAdId;
            if (Application.platform == RuntimePlatform.Android)
            {
                adId = androidAdId;
            }

            if (GameController.DebugMode)
                adId = GameController.RewardedTestId;

            _rewarded = new RewardedAd(adId);
            var adRequest = new AdRequest.Builder().Build();
            _rewarded.OnAdLoaded += AdLoaded;
            _rewarded.OnUserEarnedReward += onReward;
            _rewarded.LoadAd(adRequest);
        });
    }


    private void AdLoaded(object sender, EventArgs args)
    {
        _rewarded.Show();
    }
}