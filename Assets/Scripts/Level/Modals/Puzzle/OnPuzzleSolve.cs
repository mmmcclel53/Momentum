using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ASMaterialIcon;

public class OnPuzzleSolve : MonoBehaviour {

  public GameObject starsContainer;
  private float time;
  private GameObject starToAnimate;
  private int newScore;

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

  private void activateStar(GameObject star, bool animate) {
    float intervalTime = (time%0.5f);
    star.SetActive(true);

    Color color = star.GetComponent<MaterialVectorIcon>().color;
    color.a = intervalTime*2;
    star.GetComponent<MaterialVectorIcon>().color = color;

    if (animate) {
      if (intervalTime <= 0.25f) {
        star.transform.localScale = new Vector3(intervalTime*8f, intervalTime*8f, 1);
      } else {
        star.transform.localScale = new Vector3(2f-(intervalTime*2f), 2f-(intervalTime*2f), 1);
      }

      star.transform.Rotate(0, 0, -20*intervalTime);
      if (star.transform.localEulerAngles.z <= 288) {
        star.transform.rotation = Quaternion.Euler(0, 0, 288);
      }
    }
  }

  void Start() {
    time = 0;
    newScore = LevelUtility.calculateStarScore();
    int level = LevelUtility.calculateIndex(LevelManager.level) - 1;
    int currentBest = GameManager.currentBest;
    int currentScore = GameManager.currentStars[level];
    
    // New High Score OR New Best Move Solution
    if (newScore > currentScore || (currentBest == 0 || currentBest > LevelManager.moves)) {
      GameManager.currentBest = (currentBest == 0 || currentBest > LevelManager.moves) ? LevelManager.moves : currentBest;
      GameManager.currentStars[level] = newScore > currentScore ? newScore : currentScore;
      GameManager.totalStars += (newScore - currentScore);
      GameManager.saveLevelScore(GameManager.currentBest, GameManager.currentStars[level]);
    }

    // On New High Score, give hints
    if (newScore > currentScore) {
      int hints = newScore - currentScore;
      if ((LevelManager.difficulty == "easy" || LevelManager.difficulty == "medium") && newScore == 3) {
        GameManager.playerHints += 1;
      } else if ((LevelManager.difficulty == "hard" || LevelManager.difficulty == "master") && newScore >= 2) {
        GameManager.playerHints += Math.Min(hints, 2);
      } else if (LevelManager.difficulty == "impossible") {
        GameManager.playerHints += hints;
      }
      GameManager.savePlayerDetails();
    }

    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = getSuccessText(newScore);
  }

  void Update() {
    time += Time.deltaTime;
    if (time <= 0.5) {
      if (newScore >= 1) {
        starToAnimate = starsContainer.transform.GetChild(0).gameObject;
        activateStar(starToAnimate, true);
      } else {
        starToAnimate = starsContainer.transform.GetChild(3).gameObject;
        activateStar(starToAnimate, false);
      }
    } else if (time <= 1.0) {
      if (newScore >= 2) {
        starToAnimate = starsContainer.transform.GetChild(1).gameObject;
        activateStar(starToAnimate, true);
      } else {
        starToAnimate = starsContainer.transform.GetChild(4).gameObject;
        activateStar(starToAnimate, false);
      }
    } else if (time <= 1.5) {
      if (newScore == 3) {
        starToAnimate = starsContainer.transform.GetChild(2).gameObject;
        activateStar(starToAnimate, true);
      } else {
        starToAnimate = starsContainer.transform.GetChild(5).gameObject;
        activateStar(starToAnimate, false);
      }
    }
  }
}
