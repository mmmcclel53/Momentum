using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameManager {
  public static string difficulty;
  public static string gameType;
  public static string level;

  public static int[] easyStars;
  public static int[] mediumStars;
  public static int[] hardStars;
  public static int[] masterStars;
  public static int[] impossibleStars;

  public static void Load(string sceneName) {
    SceneManager.LoadScene(sceneName);
  }
}

[System.Serializable]
public class Rank {
  public string title;
  public int experience;
}

[System.Serializable]
public class Stars {
  public int score;
}