using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsDifficultyPanel : MonoBehaviour {

  private int STARS_TO_UNLOCK_MEDIUM = 100;
  private int STARS_TO_UNLOCK_HARD = 200;
  private int STARS_TO_UNLOCK_MASTER = 300;
  private int STARS_TO_UNLOCK_IMPOSSIBLE = 400;
  private int TOTAL_STARS = 600;

  public GameObject percentageText;
  public GameObject loadingBar;
  public GameObject nextDifficultyUnlock;
  public GameObject difficultyList;
  private float animatePercentage;
  private static float fillAmount;

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
    
    fillAmount = GameManager.totalStars < STARS_TO_UNLOCK_IMPOSSIBLE ? (GameManager.totalStars % 100) / 100f : (float) GameManager.totalStars / TOTAL_STARS;
    loadingBar.GetComponent<Image>().fillAmount = animatePercentage;
    percentageText.GetComponent<Text>().text = Mathf.FloorToInt((float)System.Math.Round(animatePercentage * 100f, 2)).ToString();

    if (GameManager.totalStars < STARS_TO_UNLOCK_IMPOSSIBLE) {
      nextDifficultyUnlock.GetComponent<Text>().text = getNextDifficultyUnlockText();
    } else {
      nextDifficultyUnlock.transform.parent.GetChild(1).gameObject.SetActive(false);
      nextDifficultyUnlock.transform.parent.GetChild(2).gameObject.SetActive(false);
      nextDifficultyUnlock.transform.parent.GetChild(3).gameObject.SetActive(true);
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

  void Update() {
    if (fillAmount - animatePercentage > 0.005f) {
      animatePercentage += (fillAmount - animatePercentage) / 20f;
      loadingBar.GetComponent<Image>().fillAmount = animatePercentage;
      percentageText.GetComponent<Text>().text = Mathf.FloorToInt((float)System.Math.Round(animatePercentage * 100f, 2)).ToString();
    } else if (animatePercentage != fillAmount) {
      animatePercentage = fillAmount;
      loadingBar.GetComponent<Image>().fillAmount = animatePercentage;
      percentageText.GetComponent<Text>().text = Mathf.FloorToInt((float)System.Math.Round(animatePercentage * 100f, 2)).ToString();
    }
  }

  void OnDisable() {
    animatePercentage = 0f;
    loadingBar.GetComponent<Image>().fillAmount = 0;
    percentageText.GetComponent<Text>().text = "0";
  }
}
