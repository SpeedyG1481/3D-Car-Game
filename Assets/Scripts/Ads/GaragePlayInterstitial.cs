using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class GaragePlayInterstitial
{
    private InterstitialAd _interstitial;

    private string androidAdId = "ca-app-pub-8847668020520840~4064880005";
    private string iOSAdId = "ca-app-pub-8847668020520840~9125634992";

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