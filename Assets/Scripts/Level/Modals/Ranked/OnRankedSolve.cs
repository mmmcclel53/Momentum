﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnRankedSolve : MonoBehaviour {

  private const int MAX_EXPERIENCE_POSSIBLE = 50;

  // Essentially add 5s more for each complexity, but bump the buffer +5 for each new difficulty
  private int[] PAR_TIME = new int[25] {
    5, 10, 15, 20, 25,        // Easy + 5
    35, 45, 55, 65, 75,       // Medium + 10
    90, 115, 130, 145, 160,   // Hard + 15
    180, 200, 220, 240, 260,  // Master + 20
    285, 310, 335, 360, 385   // Impossible + 25
  };

  private string[] RANKS = new string[10] {"Novice", "Apprentice", "Adept", "Veteran", "Expert", "Elite", "Ace", "Legend", "Mythic", "Transcendant"};
  private int[] XP_TO_NEXT_RANK = new int[10] {0, 500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 5000};
  
  private void updateDisplays(int newXP) {
    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = GameManager.playerRank;
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = (newXP > 0 ? "+" : "") + newXP.ToString();

    int indexOfNextRank = Array.FindIndex(RANKS, x => x.Contains(GameManager.playerRank)) + 1;
    int XP_OF_CURRENT_RANK = XP_TO_NEXT_RANK[indexOfNextRank-1];
    this.gameObject.transform.GetChild(2).gameObject.GetComponent<Slider>().value = (float)(GameManager.playerExperience-XP_OF_CURRENT_RANK) / (float)(XP_TO_NEXT_RANK[indexOfNextRank]-XP_OF_CURRENT_RANK);    
    this.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = GameManager.playerExperience == 5000 ? "MAX RANK" : GameManager.playerExperience + " / " + XP_TO_NEXT_RANK[indexOfNextRank];
  }

  private string getNewRank() {
    int index = 0;
    int xp = GameManager.playerExperience;
    string newRank = null;
    bool rankFound = false;
    while (!rankFound) {
      if (xp >= XP_TO_NEXT_RANK[index]) {
        newRank = RANKS[index];
      } else {
        rankFound = true;
      }
      index++;
    }
    return newRank;
  }

  private int getParTime() {
    int complexity = Int32.Parse(LevelUtility.calculateRankedLevel().Split('_')[0]);
    return PAR_TIME[complexity];
  }

  private int getStarXP() {
    double starEfficiency = LevelUtility.calculateStarScore() / 3;
    return Convert.ToInt32(Math.Floor(starEfficiency * MAX_EXPERIENCE_POSSIBLE));
  }

  private int getTimeXP() {
    double timeEfficiency = getParTime() / LevelManager.time;
    if (timeEfficiency > 1) {
      return Convert.ToInt32(Math.Min(Math.Round(timeEfficiency * MAX_EXPERIENCE_POSSIBLE, 0), MAX_EXPERIENCE_POSSIBLE));
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