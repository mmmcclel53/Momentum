using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnRankedSolve : MonoBehaviour {

  private static float animateXP;
  private static int newXP;
  private static int oldXP;
  private const int MAX_EXPERIENCE_POSSIBLE = 50;

  // Essentially add 5s more for each complexity, but bump the buffer +5 for each new difficulty
  private int[] PAR_TIME = new int[20] {
    10, 10, 10, 10,        // Easy 10
    15, 20, 25, 30,        // Medium + 5
    40, 50, 60, 70,        // Hard + 10
    85, 100, 115, 130,     // Master + 15
    150, 170, 190, 210     // Impossible + 20
  };

  private int getParSolution() {
    int bestSolution = LevelManager.solution.Length;
    return Mathf.FloorToInt(bestSolution*1.5f); // 1.5x best solution
  }

  private int getSolutionXP() {
    double solutionEfficiency = (double) getParSolution() / LevelManager.moves;
    if (solutionEfficiency > 1) {
      int bestSolution = LevelManager.solution.Length;
      double solutionBonus = (LevelManager.moves / bestSolution);
      return Convert.ToInt32(Math.Round(solutionBonus * MAX_EXPERIENCE_POSSIBLE, 0));
    } else if (solutionEfficiency == 1) {
      return 0;
    } else {  
      return Convert.ToInt32(Math.Max(Math.Round((1 - solutionEfficiency) * -MAX_EXPERIENCE_POSSIBLE, 0), -MAX_EXPERIENCE_POSSIBLE));
    }
  }

  private int getParTime() {
    // If Transcendent, begin calculating actual ranked score by slowly lowering time to complete
    if (GameManager.rankedExperience > 5000) {
      int handicap = Mathf.FloorToInt((GameManager.rankedExperience - 5000) / 10);
      return PAR_TIME[19] - handicap;
    }

    int complexity = Int32.Parse(LevelUtility.calculateRankedLevel().Split('_')[0]);
    return PAR_TIME[complexity];
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

  private void animateDisplays(int newExperience) {
    // NewXP
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = ((oldXP+newExperience) + "  (" + (newExperience > 0 ? "+" : "") + newExperience.ToString() + ")").ToString();

    int index = Array.FindIndex(GameManager.RANKS, x => x.Contains(GameManager.rankedTitle));
    int XP_OF_CURRENT_RANK = GameManager.RANK_XP[index];
    
    // Slider
    this.gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>().value =
      GameManager.rankedTitle == "Transcendent"
      ? 1
      : (float)(oldXP+newExperience-XP_OF_CURRENT_RANK) / (float)(GameManager.RANK_XP[index+1]-XP_OF_CURRENT_RANK);
  }

  void Start() {
    animateXP = 0;
    newXP = getSolutionXP() + getTimeXP();
    oldXP = GameManager.rankedExperience;
    GameManager.adjustRankedExperience(newXP);
    GameManager.saveRankedScore();

    // Icon and Rank
    Sprite icon = Resources.Load <Sprite> (("Ranks/" + GameManager.rankedTitle).ToString());
    this.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    this.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.rankedTitle;

    int index = Array.FindIndex(GameManager.RANKS, x => x.Contains(GameManager.rankedTitle));

    // Next Rank
    this.gameObject.transform.GetChild(2).transform.GetChild(3).gameObject.GetComponent<Text>().text =
      GameManager.rankedTitle == "Transcendent"
      ? "MAX RANK"
      : ("Next: " + GameManager.RANKS[index+1]).ToString();

    LevelManager.time = 0;
  }

  void Update() {
    if (newXP - animateXP > 0.5f) {
      animateXP += (newXP - animateXP) / 20f;
      animateDisplays(Mathf.FloorToInt(animateXP));
    } else if (animateXP != newXP) {
      animateXP = newXP;
      animateDisplays(Mathf.FloorToInt(animateXP));
    }
  }
}
