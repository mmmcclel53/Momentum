using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour {

  public GameObject unlockInfo;
  private static string[] shipUnlockReqs = {
    null, // Default Ship
    "100% Easy", "100% Medium", "100% Hard", "100% Master", "100% Impossible",
    "Apprentice Rank", "Veteran Rank", "Elite Rank", "Legend Rank", "Transcendent Rank",
    "???"
  };
  private static string[] rewardUnlockReqs = {
    "Complete the Easy Time Trials", "Complete the Medium Time Trials", "Complete the Hard Time Trials", "Complete the Master Time Trials", "Complete the Impossible Time Trials"
  };

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
      unlockInfo.transform.GetChild(2).gameObject.GetComponent<Text>().text = ("Requirement:\n" + shipUnlockReqs[index]).ToString();
    }
    setImage();
  }

  public void onRewardClick(int index) {
    setImage();
  }

}
