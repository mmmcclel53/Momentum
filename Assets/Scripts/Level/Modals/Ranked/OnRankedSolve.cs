using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnRankedSolve : MonoBehaviour {

  private const int MAX_EXPERIENCE_POSSIBLE = 50;

  // Essentially add 5s more for each complexity, but bump the buffer +5 for each new difficulty
  private int[] PAR_TIME = new int[20] {
    5, 5, 7, 10,           // Easy + ~2.5
    15, 20, 25, 30,        // Medium + 5
    40, 50, 60, 70,        // Hard + 10
    85, 100, 115, 130,     // Master + 15
    150, 170, 190, 210     // Impossible + 20
  };
  
  private void updateDisplays(int newXP) {
    // Icon and Rank
    Sprite icon = Resources.Load <Sprite> (("Ranks/" + GameManager.playerRank).ToString());
    this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.playerRank;

    // NewXP
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = (GameManager.playerExperience + "  (" + (newXP > 0 ? "+" : "") + newXP.ToString() + ")").ToString();

    int index = Array.FindIndex(GameManager.RANKS, x => x.Contains(GameManager.playerRank));
    int XP_OF_CURRENT_RANK = GameManager.RANK_XP[index];
    
    // Slider
    this.gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>().value =
      GameManager.playerRank == "Transcendent"
      ? 1
      : (float)(GameManager.playerExperience-XP_OF_CURRENT_RANK) / (float)(GameManager.RANK_XP[index+1]-XP_OF_CURRENT_RANK);    
    
    // Next Rank
    this.gameObject.transform.GetChild(2).transform.GetChild(3).gameObject.GetComponent<Text>().text =
      GameManager.playerRank == "Transcendent"
      ? "MAX RANK"
      : ("Next: " + GameManager.RANKS[index+1]).ToString();
  }

  private int getParTime() {
    // Boi you good
    if (GameManager.playerExperience > 5000) {
      int ratio = Mathf.FloorToInt(GameManager.playerExperience / PAR_TIME[19]);
      return Mathf.FloorToInt(GameManager.playerExperience / ratio);
    }

    int complexity = Int32.Parse(LevelUtility.calculateRankedLevel().Split('_')[0]);
    return PAR_TIME[complexity];
  }

  private int getStarXP() {
    float starEfficiency = LevelUtility.calculateStarScore() / 3;
    return Mathf.FloorToInt(starEfficiency * MAX_EXPERIENCE_POSSIBLE);
  }

  private int getTimeXP() {
    double timeEfficiency = getParTime() / LevelManager.time;
    if (timeEfficiency > 1) {
      double timeBonus = 1 - (LevelManager.time / getParTime());
      return Convert.ToInt32(Math.Round(timeBonus * MAX_EXPERIENCE_POSSIBLE, 0));
    } else if (timeEfficiency == 1) {
      return 0;
    } else {
      return Convert.ToInt32(Math.Max(Math.Round((1 - timeEfficiency) * -MAX_EXPERIENCE_POSSIBLE, 0), -MAX_EXPERIENCE_POSSIBLE));
    }
  }

  void Start() {
    int newXP = getStarXP() + getTimeXP();
    GameManager.adjustPlayerExperience(newXP);
    GameManager.savePlayerDetails();

    updateDisplays(newXP);

    LevelManager.time = 0;
  }
}
