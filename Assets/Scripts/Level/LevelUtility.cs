using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public static class LevelUtility {

  public static string[] difficulties = {"easy", "medium", "hard", "master", "impossible"};

  // Change levels to 1-40 index. Delete this later.
  public static int calculateIndex(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    // Mega gross
    return ((complexity % 4) * 10) + number;
  }

  public static string calculateRankedDifficulty() {
    int exp = GameManager.rankedExperience;
    if (exp < 1000) {
      return "easy";
    } else if (exp < 2000) {
      return "medium";
    } else if (exp < 3000) {
      return "hard";
    } else if (exp < 4000) {
      return "master";
    } else {
      return "impossible";
    } 
  }

  public static string calculateRankedLevel() {
    System.Random random = new System.Random();
    string randomLevel = random.Next(1, 100).ToString();

    int exp = GameManager.rankedExperience;
    if (exp < 250) {
      return "0_" + randomLevel;
    } else if (exp < 500) {
      return "1_" + randomLevel;
    } else if (exp < 750) {
      return "2_" + randomLevel;
    } else if (exp < 1000) {
      return "3_" + randomLevel;
    } else if (exp < 1250) {
      return "4_" + randomLevel;
    } else if (exp < 1500) {
      return "5_" + randomLevel;
    } else if (exp < 1750) {
      return "6_" + randomLevel;
    } else if (exp < 2000) {
      return "7_" + randomLevel;
    } else if (exp < 2250) {
      return "8_" + randomLevel;
    } else if (exp < 2500) {
      return "9_" + randomLevel;
    } else if (exp < 2750) {
      return "10_" + randomLevel;
    } else if (exp < 3000) {
      return "11_" + randomLevel;
    } else if (exp < 3250) {
      return "12_" + randomLevel;
    } else if (exp < 3500) {
      return "13_" + randomLevel;
    } else if (exp < 3750) {
      return "14_" + randomLevel;
    } else if (exp < 4000) {
      return "15_" + randomLevel;
    } else if (exp < 4250) {
      return "16_" + randomLevel;
    } else if (exp < 4500) {
      return "17_" + randomLevel;
    } else if (exp < 4750) {
      return "18_" + randomLevel;
    } else {
      return "19_" + randomLevel;
    }
  }

  public static string calculateTimeTrialLevel() {
    System.Random random = new System.Random();

    int complexity = 0;
    int complexityBuffer = Mathf.FloorToInt(LevelManager.currentSolved / 2);
    if (LevelManager.difficulty == "easy") {
      complexity = Mathf.Min(complexityBuffer, 3);
    } else if (LevelManager.difficulty == "medium") {
      complexity = Mathf.Min(4 + complexityBuffer, 7);
    } else if (LevelManager.difficulty == "hard") {
      complexity = Mathf.Min(8 + complexityBuffer, 11);
    }
    
    int randomLevel = random.Next(1, 100);
    return (complexity + "_" + randomLevel).ToString();
  }

  public static int getTimeTrialSecondsToComplete() {
    if (LevelManager.difficulty == "easy") {
      return 75;
    } else if (LevelManager.difficulty == "medium") {
      return 150;
    } else if (LevelManager.difficulty == "hard") {
      return 240;
    }
    return 75;
  }

  public static int calculateStarScore() {
    int bestSolution = LevelManager.solution.Length;
    int moves = LevelManager.moves;
    int twoStarSolution = Mathf.FloorToInt(bestSolution*0.667f) + bestSolution;
    if (moves <= bestSolution) {
      return 3;
    } else if (moves <= twoStarSolution) {
      return 2;
    } else {
      return 1;
    }
  }

  public static int calculateBoardSize() {
    switch (LevelManager.difficulty) {
      case "easy":
        return 6;
      case "medium":
        return 8;
      case "hard":
        return 10;
      case "master":
        return 12;
      case "impossible":
        return 14;
      default:
        return 6;
    }
  }
}
