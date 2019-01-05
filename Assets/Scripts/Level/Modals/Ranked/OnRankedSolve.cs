using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  private string[] RANKS = new string[10] {"Novice", "Apprentice", "Adept", "Veteran", "Expert", "Elite", "Ace", "Legend", "Mythic", "Transcendent"};
  private int[] XP_TO_NEXT_RANK = new int[10] {500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000};
  
  private void updateDisplays(int newXP) {
    // Icon and Rank
    Sprite icon = Resources.Load <Sprite> (("Ranks/" + GameManager.playerRank).ToString());
    this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.playerRank;

    // NewXP
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = (GameManager.playerExperience + "  (" + (newXP > 0 ? "+" : "") + newXP.ToString() + ")").ToString();

    int index = Array.FindIndex(RANKS, x => x.Contains(GameManager.playerRank));
    int XP_OF_CURRENT_RANK = XP_TO_NEXT_RANK[index];
    
    // Slider
    this.gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>().value =
      GameManager.playerRank == "Transcendent"
      ? 1
      : (float)(GameManager.playerExperience-XP_OF_CURRENT_RANK) / (float)(XP_TO_NEXT_RANK[index+1]-XP_OF_CURRENT_RANK);    
    
    // Next Rank
    this.gameObject.transform.GetChild(2).transform.GetChild(3).gameObject.GetComponent<Text>().text =
      GameManager.playerRank == "Transcendent"
      ? "MAX RANK"
      : ("Next: " + RANKS[index+1]).ToString();
  }

  private string getNewRank() {
    for (int i=0; i<10; i++) {
      if (GameManager.playerExperience < XP_TO_NEXT_RANK[i]) {
        return RANKS[Math.Max(i-1, 0)];
      }
    }
    return "Transcendent";
  }

  private int getParTime() {
    int complexity = Int32.Parse(LevelUtility.calculateRankedLevel().Split('_')[0]);
    return PAR_TIME[complexity];
  }

  private int getStarXP() {
    double starEfficiency = (double)LevelUtility.calculateStarScore() / 3;
    return Convert.ToInt32(Math.Floor(starEfficiency * MAX_EXPERIENCE_POSSIBLE));
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
    GameManager.playerRank = getNewRank();
    GameManager.savePlayerDetails();

    updateDisplays(newXP);

    LevelManager.time = 0;
  }
}
