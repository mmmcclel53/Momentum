using UnityEngine;

// Getters/Setters
public static class LevelManager {

  // "Level/" + difficulty + level ".txt"
  public static string difficulty = "hard";
  public static string level = "8_1";

  public static float time = 0;
  public static int moves = 0;

  public static bool solved = false;
  public static Vector3Int goalTile;
  public static string[] solution = null;
}
