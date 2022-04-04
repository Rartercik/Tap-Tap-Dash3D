using UnityEngine.Advertisements;

public class AdsShower : IUnityAdsShowListener
{
    private AdsCounter _adsCounter;
    private AdsCompleteImage _adsCompleteImage;

    public AdsShower(AdsCounter adsCounter, AdsCompleteImage adsCompleteImage)
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize("4632732", false);
        _adsCounter = adsCounter;
        _adsCompleteImage = adsCompleteImage;
    }

    public void TryShowAds()
    {
        if(_adsCounter.HasEnoughCount)
        {
            Advertisement.Show("Interstitial_Android", this);
            _adsCounter.SetToZero();
        }
        else
        {
            _adsCounter.UpdateAdsCount();
        }
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        _adsCompleteImage.ShowImage();
    }

    public void OnUnityAdsShowClick(string placementId) { }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }
    public void OnUnityAdsShowStart(string placementId) { }
}

