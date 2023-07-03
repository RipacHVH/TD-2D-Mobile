using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    private string _gameId;

    //rewarded
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    public bool GetMoney = false;
    public void RunRewardedAD()
    {
        if (Advertisement.isInitialized)
        {

            Debug.Log("AD is Shown");
            LoadRewardedAd();
        }
        else
        {
            InitializeAds();
        }
    }
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;
        InitializeAds();
        //LoadRewardedAd();
    }
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Init Success");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
    public void LoadInerstitialAd() 
    {
        Advertisement.Load(_adUnitId, this);
    }

    public void LoadRewardedAd()
    {
        Advertisement.Load(_adUnitId, this);
        Debug.Log("Loaded");
    }

    /*public void ShowRewardedAd()
    {
        Advertisement.Show(_adUnitId, this);
        //LoadRewardedAd();
    }*/

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_adUnitId) && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            if(GetMoney)
            {
                GameObject.Find("Currency").GetComponent<Currency>().money += 1000f;
                GetMoney = false;
            }
        }
        Time.timeScale = GameObject.Find("TimeScale").GetComponent<TimeScale>().CurrentTimeScale;
    }
}