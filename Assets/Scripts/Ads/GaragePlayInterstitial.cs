using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class GaragePlayInterstitial
{
    private InterstitialAd _interstitial;

    private string androidAdId = "ca-app-pub-8847668020520840/5374678976";
    private string iOSAdId = "ca-app-pub-8847668020520840/6033154529";

    public void Initialize()
    {
        MobileAds.Initialize(x =>
        {
            var adId = iOSAdId;
            if (Application.platform == RuntimePlatform.Android)
            {
                adId = androidAdId;
            }

            if (GameController.DebugMode)
                adId = GameController.InterstitialTestId;

            _interstitial = new InterstitialAd(adId);
            var adRequest = new AdRequest.Builder().Build();
            _interstitial.OnAdLoaded += AdLoaded;
            _interstitial.LoadAd(adRequest);
        });
    }


    private void AdLoaded(object sender, EventArgs args)
    {
        _interstitial.Show();
    }
}