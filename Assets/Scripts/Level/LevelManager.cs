using UnityEngine;
using System.Collections.Generic;

public class Move {
  public GameObject movingObj;
  public Swipe swipeDirection;
  public Vector3 start;
  public Vector3 end;
  public Move(GameObject mo, Swipe dir, Vector3 startPos, Vector3 endPos) {
    movingObj = mo;
    swipeDirection = dir;
    start = startPos;
    end = endPos;
  }
}

// Getters/Setters
public static class LevelManager {

  // "Level/" + difficulty + level ".txt"
  public static string difficulty = "easy";
  public static string level = "0_1";

  public static float time = 0;
  public static List<Move> moves = new List<Move>();

  // Time Trials
  public static int currentSolved = 0;

  public static bool solved = false;
  public static bool paused = false;
  public static Vector3Int goalTile;
  public static string[] solution = null;
}
