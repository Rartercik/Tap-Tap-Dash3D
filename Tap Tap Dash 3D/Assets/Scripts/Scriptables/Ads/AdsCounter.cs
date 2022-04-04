using UnityEngine;
using UnityEngine.Advertisements;

[CreateAssetMenu()]
public class AdsCounter : ScriptableObject
{
    [SerializeField] int _adsFrequency;

    private int _gamesCount;

    public bool HasEnoughCount => _gamesCount >= _adsFrequency && Advertisement.isInitialized;

    public void UpdateAdsCount()
    {
        _gamesCount++;
    }
    public void SetToZero()
    {
        _gamesCount = 0;
    }
}
