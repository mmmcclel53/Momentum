using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
  
  public GameObject DifficultyListView;
  public GameObject LevelsListView;
  public GameObject Level;
  public string difficulty;

  private int STARS_TO_UNLOCK_MEDIUM = 150;
  private int STARS_TO_UNLOCK_HARD = 350;
  private int STARS_TO_UNLOCK_MASTER = 550;
  private int STARS_TO_UNLOCK_IMPOSSIBLE = 900;

  private string EASY_BG_COLOR = "#1978D6";
  private string MEDIUM_BG_COLOR = "#00730C";
  private string HARD_BG_COLOR = "#CC922D";
  private string MASTER_BG_COLOR = "#CC312D";
  private string IMPOSSIBLE_BG_COLOR = "#202020";

  private string getBackgroundColor(string difficulty) {
    switch (difficulty) {
      case "easy":
        return EASY_BG_COLOR;
      case "medium":
        return MEDIUM_BG_COLOR;
      case "hard":
        return HARD_BG_COLOR;
      case "master":
        return MASTER_BG_COLOR;
      case "impossible":
        return IMPOSSIBLE_BG_COLOR;
      default:
        return IMPOSSIBLE_BG_COLOR;
    }
  }

  private int[] getCurrentStars(string difficulty) {
    switch (difficulty) {
      case "easy":
        return GameManager.easyStars;
      case "medium":
        return GameManager.mediumStars;
      case "hard":
        return GameManager.hardStars;
      case "master":
        return GameManager.masterStars;
      case "impossible":
        return GameManager.impossibleStars;
      default:
        return GameManager.easyStars;
    }
  }

  private void resetLevelContentItems(GameObject listContent) {
    for (int i=1; i<listContent.transform.childCount; i++) {
      Destroy(listContent.transform.GetChild(i).gameObject);
    }
    Level.SetActive(true);
  }

  private void setColumnCount(GameObject listContent) {
    GridLayoutGroup listGrid = listContent.GetComponent<GridLayoutGroup>();
    float gridWidth = listContent.GetComponent<RectTransform>().rect.width;
    int columnCount = Mathf.FloorToInt(gridWidth / (listGrid.cellSize.x + (listGrid.spacing.x * 2)) );
    listGrid.constraintCount = columnCount;
  }

  private void setLevelContentItems(GameObject listContent) {
    
    resetLevelContentItems(listContent);

    // Set Levels Background
    Color color;
    if (ColorUtility.TryParseHtmlString(getBackgroundColor(LevelManager.difficulty), out color)) {
      Level.GetComponent<Image>().color = color;
    }

    for (int i=0; i<GameManager.currentStars.Length; i++) {
      GameObject clone = Instantiate(Level);
      clone.transform.parent = listContent.transform;
      clone.transform.localScale = new Vector3(1,1,1);

      // Set Level #
      GameObject itemTextContainer = clone.transform.GetChild(0).gameObject;
      itemTextContainer.GetComponent<Text>().text = (i + 1).ToString();

      // Set Star Icons
      Transform itemStarContainer = clone.transform.GetChild(1).gameObject.transform;
      if (GameManager.currentStars[i] > 0) {
        for (int j=0; j<GameManager.currentStars[i]; j++) {
          itemStarContainer.GetChild(j).gameObject.SetActive(true);
        }
      }
    }
    Level.SetActive(false);
  }

  public void onDifficultyClick(string difficulty) {

    if (difficulty == "medium" && GameManager.totalStars < STARS_TO_UNLOCK_MEDIUM) {
      return;
    } else if (difficulty == "hard" && GameManager.totalStars < STARS_TO_UNLOCK_HARD) {
      return;
    }

    LevelManager.difficulty = difficulty;
    GameManager.currentStars = getCurrentStars(difficulty);

    GameObject listContent = LevelsListView.transform.GetChild(1).transform.GetChild(0).gameObject;
    setColumnCount(listContent);
    setLevelContentItems(listContent);

    DifficultyListView.SetActive(false);
    LevelsListView.SetActive(true);
	}

  void Start() {
    if (difficulty == "medium" && GameManager.totalStars >= STARS_TO_UNLOCK_MEDIUM) {
      this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    } else if (difficulty == "hard" && GameManager.totalStars >= STARS_TO_UNLOCK_HARD) {
      this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    
    if (GameManager.totalStars >= STARS_TO_UNLOCK_MASTER) {
      this.gameObject.transform.parent.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
    if (GameManager.totalStars >= STARS_TO_UNLOCK_IMPOSSIBLE) {
      this.gameObject.transform.parent.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
  }
}
