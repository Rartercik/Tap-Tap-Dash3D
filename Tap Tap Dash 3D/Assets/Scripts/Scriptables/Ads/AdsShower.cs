using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

[CreateAssetMenu()]
public class AdsShower : ScriptableObject
{
    [SerializeField] int _adsFrequency;

    private int _gamesCount;

    public void UpdateAds()
    {
        if (Advertisement.isSupported)
            Advertisement.Initialize("4632732", false);

        if (_gamesCount < _adsFrequency) _gamesCount++;

        if (_gamesCount >= _adsFrequency && Advertisement.isInitialized)
        {
            Advertisement.Show("Interstitial_Android");
            _gamesCount = 0;
        }
    }
}
