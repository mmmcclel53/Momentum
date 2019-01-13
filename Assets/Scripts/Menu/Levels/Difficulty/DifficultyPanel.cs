using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyPanel : MonoBehaviour {

  private int STARS_TO_UNLOCK_MEDIUM = 100;
  private int STARS_TO_UNLOCK_HARD = 200;
  private int STARS_TO_UNLOCK_MASTER = 300;
  private int STARS_TO_UNLOCK_IMPOSSIBLE = 400;

  private string[] difficultyUnlocks = {"", "", ""};

  public GameObject loadingBar;
  public GameObject nextDifficultyUnlock;
  public GameObject difficultyList;

  private string getNextDifficultyUnlockText() {
    if (GameManager.totalStars < STARS_TO_UNLOCK_MEDIUM) {
      return "Medium";
    } else if (GameManager.totalStars < STARS_TO_UNLOCK_HARD) {
      return "Hard";
    } else {
      return "???";
    }
  }

	void Start() {

    float fillAmount = GameManager.totalStars < STARS_TO_UNLOCK_IMPOSSIBLE ? GameManager.totalStars / 100f : 1;    
    loadingBar.GetComponent<Image>().fillAmount = fillAmount;

    if (GameManager.totalStars < STARS_TO_UNLOCK_IMPOSSIBLE) {
      nextDifficultyUnlock.GetComponent<Text>().text = getNextDifficultyUnlockText();
    } else {
      Destroy(nextDifficultyUnlock.transform.parent.GetChild(0));
      Destroy(nextDifficultyUnlock.transform.parent.GetChild(1));
      nextDifficultyUnlock.transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    if (GameManager.totalStars >= STARS_TO_UNLOCK_MEDIUM) {
      difficultyList.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    if (GameManager.totalStars >= STARS_TO_UNLOCK_HARD) {
      difficultyList.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    if (GameManager.totalStars >= STARS_TO_UNLOCK_MASTER) {
      difficultyList.transform.GetChild(3).gameObject.SetActive(true);
    }
    if (GameManager.totalStars >= STARS_TO_UNLOCK_IMPOSSIBLE) {
      difficultyList.transform.GetChild(4).gameObject.SetActive(true);
    }
  }
}
