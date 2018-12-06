using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
  public static string gameType = "puzzles";

  // TODO: Player class/object
  public static int playerExperience = 0;
  public static string playerRank = "Novice";

  public static int currentBest;
  public static int[] currentStars;
  public static int[] easyStars;
  public static int[] mediumStars;
  public static int[] hardStars;
  public static int[] masterStars;
  public static int[] impossibleStars;
  public static int totalStars = 0;

  public static void Load(string sceneName) {
    SceneManager.LoadScene(sceneName);
  }

  public static void adjustPlayerExperience(int adjustment) {
    if (playerExperience + adjustment < 0) {
      playerExperience = 0;
    } else if (playerExperience + adjustment >= 5000) {
      playerExperience = 5000;
    } else {
      playerExperience += adjustment;
    }
  }

  public static void loadCurrentBest() {
    try {
      FileStream file = File.Open(Application.persistentDataPath + "/" + LevelManager.difficulty + LevelManager.level + ".dat", FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      PuzzleScore puzzleScore = (PuzzleScore)bf.Deserialize(file);
      currentBest = puzzleScore.best;
      file.Close();
    } catch {
      currentBest = 0;
    }
  }

  // Total stars per difficulty, from memory
  private static int[] getStars(string difficulty) {
    int[] stars = new int[75];
    DirectoryInfo directory = new DirectoryInfo(Application.persistentDataPath);
    FileInfo[] files = directory.GetFiles("*.dat");
    BinaryFormatter bf = new BinaryFormatter();
    foreach (FileInfo f in files) {
      if (f.Name.Contains(difficulty)) {
        FileStream file = File.Open(Application.persistentDataPath + "/" + f.Name, FileMode.Open);
        PuzzleScore puzzleScore = (PuzzleScore)bf.Deserialize(file);
        file.Close();

        int index = LevelUtility.calculateIndex(f.Name.Replace(difficulty, "").Replace(".dat", "")) - 1;
        stars[index] = puzzleScore.stars;
      }
    }
    return stars;
  }

  public static void loadPlayerDetails() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
      
    PlayerDetails player = (PlayerDetails)bf.Deserialize(file);
    playerExperience = player.experience;
    playerRank = player.rank;

    file.Close();
  }

  public static void savePlayerDetails() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/player.dat");

    PlayerDetails player = new PlayerDetails();
    player.experience = playerExperience;
    player.rank = playerRank;

    bf.Serialize(file, player);
    file.Close();
  }

  public static void loadStars() {
    easyStars = getStars("easy");
    mediumStars = getStars("medium");
    hardStars = getStars("hard");
    masterStars = getStars("master");
    impossibleStars = getStars("impossible");
  }

  public static void saveScore(int best, int stars) {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(
      Application.persistentDataPath + "/" + LevelManager.difficulty + LevelManager.level + ".dat"
    );

    PuzzleScore puzzleScore = new PuzzleScore();
    puzzleScore.best = best;
    puzzleScore.stars = stars;

    bf.Serialize(file, puzzleScore);
    file.Close();
  }
}

[System.Serializable]
public class PlayerDetails {
  public string rank;
  public int experience;
}

[System.Serializable]
public class PuzzleScore {
  public int best;
  public int stars;
}