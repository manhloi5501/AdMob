using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class Admob : MonoBehaviour
{
    public Text adstatus;

    string App_ID = "ca-app-pub-5134338854978158~3430400668";
    
    string Banner_Ad_ID = "ca-app-pub-3940256099942544/6300978111";
    string Interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";
    string Video_AD_ID = "ca-app-pub-3940256099942544/5224354917";


    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    void Start()
    {
        MobileAds.Initialize(App_ID);
        RequestBanner();
        RequestInterstitial();
        RequestRewardBasedVideo();
    }

    private void RequestBanner()
    { 

        this.bannerView = new BannerView(Banner_Ad_ID, AdSize.Banner, AdPosition.Bottom);
    
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    
    }

    public void ShowBannerAD(){
        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }



    public void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(Interstitial_Ad_ID);

         // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }


    public void ShowInterstitialAd(){
        if (this.interstitial.IsLoaded()){
            this.interstitial.Show();
        }
    }



    public void RequestRewardBasedVideo(){

        rewardBasedVideo = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().Build();

        this.rewardBasedVideo.LoadAd(request,Video_AD_ID);

    }

    public void ShowVideoRewardAd(){
        if (rewardBasedVideo.IsLoaded()){
            rewardBasedVideo.Show();
        }
    }



    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        adstatus.text = "Ad Loaded";
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       adstatus.text = "Ad Fail To Loaded";
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

}
