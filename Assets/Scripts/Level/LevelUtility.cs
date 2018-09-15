using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public static class LevelUtility {
  // This is dumb...
  public static Vector3 addOffset(Vector3 pos) {
    pos.x += 1.5f;
    pos.y += 1.5f;
    return pos;
  }

  // Change levels to 1-75 index. Delete this later.
  public static int calculateIndex(string level) {

    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    // Impossible difficulty
    if (complexity >= 20) {
      return number;
    }

    // Mega gross
    return ((complexity % 5) * 15) + number;
  }

  public static string calculateRankedDifficulty() {
    int exp = GameManager.playerExperience;
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

    int exp = GameManager.playerExperience;
    if (exp < 200) {
      return "0_" + randomLevel + ".txt";
    } else if (exp < 400) {
      return "1_" + randomLevel + ".txt";
    } else if (exp < 600) {
      return "2_" + randomLevel + ".txt";
    } else if (exp < 800) {
      return "3_" + randomLevel + ".txt";
    } else if (exp < 1000) {
      return "4_" + randomLevel + ".txt";
    } else if (exp < 1200) {
      return "5_" + randomLevel + ".txt";
    } else if (exp < 1400) {
      return "6_" + randomLevel + ".txt";
    } else if (exp < 1600) {
      return "7_" + randomLevel + ".txt";
    } else if (exp < 1800) {
      return "8_" + randomLevel + ".txt";
    } else if (exp < 2000) {
      return "9_" + randomLevel + ".txt";
    } else if (exp < 2200) {
      return "10_" + randomLevel + ".txt";
    } else if (exp < 2400) {
      return "11_" + randomLevel + ".txt";
    } else if (exp < 2600) {
      return "12_" + randomLevel + ".txt";
    } else if (exp < 2800) {
      return "13_" + randomLevel + ".txt";
    } else if (exp < 3000) {
      return "14_" + randomLevel + ".txt";
    } else if (exp < 3200) {
      return "15_" + randomLevel + ".txt";
    } else if (exp < 3400) {
      return "16_" + randomLevel + ".txt";
    } else if (exp < 3600) {
      return "17_" + randomLevel + ".txt";
    } else if (exp < 3800) {
      return "18_" + randomLevel + ".txt";
    } else if (exp < 4000) {
      return "19_" + randomLevel + ".txt";
    } else { // > 4000
      int level = random.Next(1, 200);
      DirectoryInfo directory = new DirectoryInfo("Assets/Resources/Levels/Ranked/");
      FileInfo[] files = directory.GetFiles("impossible*.txt");

      // Random impossible puzzle
      return files[level].Name.Replace("impossible", "");
    }
  }

  public static int calculateStarScore() {
    int bestSolution = LevelManager.solution.Length;
    int moves = LevelManager.moves;
    int twoStarBuffer = 2;
    if (moves <= bestSolution) {
      return 3;
    } else if (moves <= bestSolution + twoStarBuffer) {
      return 2;
    } else {
      return 1;
    }
  }

  public static int calculateX(int tile) {
    return tile % 16;
  }

  public static int calculateY(int tile) {
    return -1 * Convert.ToInt32(Math.Floor((double)(tile/16)));
  }
}
