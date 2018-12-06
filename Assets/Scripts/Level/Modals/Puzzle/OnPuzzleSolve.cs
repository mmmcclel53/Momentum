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

  void Start() {
    int newScore = LevelUtility.calculateStarScore();
    int level = LevelUtility.calculateIndex(LevelManager.level) - 1;
    int currentBest = GameManager.currentBest;
    int currentScore = GameManager.currentStars[level];
    
    // New High Score OR New Best Move Solution
    if (newScore > currentScore || (currentBest == 0 || currentBest > LevelManager.moves)) {
      GameManager.currentBest = (currentBest == 0 || currentBest > LevelManager.moves) ? LevelManager.moves : currentBest;
      GameManager.currentStars[level] = newScore > currentScore ? newScore : currentScore;
      GameManager.saveScore(GameManager.currentBest, GameManager.currentStars[level]);
    }

    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = getSuccessText(newScore);
    for (int i=0; i<newScore; i++) {
      // TODO: Get rid of this gross traversal
      this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }
  }
}
