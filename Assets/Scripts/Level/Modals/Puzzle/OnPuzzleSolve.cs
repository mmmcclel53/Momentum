using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPuzzleSolve : MonoBehaviour {

  private string getSuccessText(int score) {
    switch (score) {
      case 3:
        return "Perfect!!!";
      case 2:
        return "Great Work!!";
      case 1:
        return "Nice Job!";
      default:
          return "Nice Job!";
    }
  }

  public void Start() {
    int newScore = LevelUtility.calculateStarScore();
    int currentScore = GameManager.currentStars[LevelUtility.calculateIndex(LevelManager.level)-1];
    if (newScore > currentScore) {
      int level = LevelUtility.calculateIndex(LevelManager.level);
      GameManager.currentStars[level-1] = newScore;
      GameManager.saveStars(newScore);
    }

    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = getSuccessText(newScore);
    for (int i=0; i<newScore; i++) {
      // TODO: Get rid of this gross traversal
      this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }
  }
}
