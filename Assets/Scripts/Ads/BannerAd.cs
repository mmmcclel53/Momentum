using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    bool testMode = true;
    private string placementId = "mainBanner";
    #if UNITY_IOS
    string gameId = "3288234";
    #elif UNITY_ANDROID
    string gameId = "3288235";
    #endif
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }
    
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }

    void OnDestroy()
    {
        Advertisement.Banner.Hide(true);
    }
}