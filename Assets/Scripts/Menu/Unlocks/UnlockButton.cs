using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UnlockButton : MonoBehaviour {

  private int STARS_TO_UNLOCK_MASTER = 300;
  private int STARS_TO_UNLOCK_IMPOSSIBLE = 400;

  private int XP_TO_SEE_VETERAN = 1500;
  private int XP_TO_SEE_ELITE = 2500;
  private int XP_TO_SEE_LEGEND = 3500;
  private int XP_TO_SEE_TRANSCENDENT = 4500;


  public GameObject unlockInfo;
  private static string[] shipUnlockReqs;
  private static string[] rewardUnlockReqs;

  void Start() {
    shipUnlockReqs = new string[] {
      null, // Default Ship
      "Obtain ALL Easy Stars", "Obtain ALL Medium Stars", "Obtain ALL Hard Stars",
      GameManager.totalStars >= STARS_TO_UNLOCK_MASTER ? "Obtain ALL Master Stars" : "???",
      GameManager.totalStars >= STARS_TO_UNLOCK_IMPOSSIBLE ? "Obtain ALL Impossible Stars" : "???",
      "Earn the Apprentice title in Ranked",
      GameManager.bestRankedExperience >= XP_TO_SEE_VETERAN ? "Earn the Veteran title in Ranked" : "???",
      GameManager.bestRankedExperience >= XP_TO_SEE_ELITE ? "Earn the Elite title in Ranked" : "???",
      GameManager.bestRankedExperience >= XP_TO_SEE_LEGEND ? "Earn the Legend title in Ranked" : "???",
      GameManager.bestRankedExperience >= XP_TO_SEE_TRANSCENDENT ? "Earn the Transcendent title in Ranked" : "???",
      "???"
    };
    rewardUnlockReqs = new string[] {
      "Clear 10 levels in Time Trials Easy", "Clear 5 levels in Time Trials Medium", "Clear 3 levels in Time Trials Hard",
      "Clear 15 levels in Time Trials Easy", "Clear 10 levels in Time Trials Medium", "Clear 5 levels in Time Trials Hard"
    };
  }

  private void setImage() {
    GameObject unlockImage = Instantiate(this.gameObject, unlockInfo.transform);
    unlockImage.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    unlockImage.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.6f);
    unlockImage.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.6f);
    unlockImage.GetComponent<RectTransform>().sizeDelta = new Vector2(180f, 180f);
    unlockImage.transform.position = new Vector3(0f, 5f, 0f);
    unlockImage.transform.SetSiblingIndex(1);
    Destroy(unlockImage.GetComponent<Button>());
  }

	public void onShipClick(int index) {
    if (GameManager.shipUnlocks[index]) {
      unlockInfo.transform.GetChild(1).gameObject.SetActive(true);
      unlockInfo.transform.GetChild(2).gameObject.SetActive(false);
    } else {
      unlockInfo.transform.GetChild(1).gameObject.SetActive(false);
      unlockInfo.transform.GetChild(2).gameObject.SetActive(true);
      unlockInfo.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ("REQUIREMENT:\n" + shipUnlockReqs[index]).ToString();
    }
    setImage();
  }

  public void onRewardClick(int index) {
    if (!GameManager.rewardUnlocks[index]) {
      unlockInfo.transform.parent.gameObject.SetActive(true);
      unlockInfo.transform.GetChild(1).gameObject.SetActive(false);
      unlockInfo.transform.GetChild(2).gameObject.SetActive(true);
      unlockInfo.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = ("REQUIREMENT:\n" + rewardUnlockReqs[index]).ToString();
      setImage();
    }
  }
}
