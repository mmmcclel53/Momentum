using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardAd : MonoBehaviour, IUnityAdsListener { 

    #if UNITY_IOS
    public string gameId = "3288234";
    #elif UNITY_ANDROID
    public string gameId = "3288235";
    #endif

    public string myPlacementId = "rewardedVideo";
    bool testMode = true;

    public Button adButton;

    // Initialize the Ads listener and service:
    void Start() {

      // Set interactivity to be dependent on the Placement’s status:
      adButton.interactable = Advertisement.IsReady(myPlacementId);
      // Map the ShowRewardedVideo function to the button’s click listener:
      if (adButton) adButton.onClick.AddListener(ShowRewardedVideo);

      Advertisement.AddListener(this);
      Advertisement.Initialize(gameId, testMode);
    }

    void ShowRewardedVideo()
    {
      Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
      // Define conditional logic for each ad completion status:
      if (showResult == ShowResult.Finished) {
        Debug.Log("Ad finished playing");
      } else if (showResult == ShowResult.Skipped) {
        // Do not reward the user for skipping the ad.
      } else if (showResult == ShowResult.Failed) {
        Debug.LogWarning ("The ad did not finish due to an error.");
      }
    }

    public void OnUnityAdsReady(string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId) {
          adButton.interactable = true;
        }
    }

    public void OnUnityAdsDidError(string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 
}