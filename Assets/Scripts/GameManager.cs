using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
  public static string gameType = "puzzles";

  // TODO: Player class/object

  // Player
  public static int playerExperience = 500;
  public static int playerHints = 0;
  public static string playerRank = "Novice";
  public static string playerShip = "ship1";

  public static int currentBest = 0;
  public static int[] currentStars;
  public static int[] easyStars;
  public static int[] mediumStars;
  public static int[] hardStars;
  public static int[] masterStars;
  public static int[] impossibleStars;
  public static int totalStars = 0;

  // Settings
  public static bool isMusicSoundsOn = true;
  public static bool isGameSoundsOn = true;
  public static float gridVisibility = 0.35f;

  public static bool[] shipUnlocks = {
    true, // Default Ship
    false, false, false, false, false, // Puzzle Ships
    false, false, false, false, false, // Rank Ships
    false // 100% Ship
  };
  public static bool[] rewardUnlocks = {
    false, false, false, false, false
  };

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

  public static void updateUnlocks() {
    const int PERFECT_STARS = 120;
    shipUnlocks = new bool[] {
      true, // Default Ship
      easyStars.Sum() == PERFECT_STARS, mediumStars.Sum() == PERFECT_STARS, hardStars.Sum() == PERFECT_STARS, masterStars.Sum() == PERFECT_STARS, impossibleStars.Sum() == PERFECT_STARS,
      playerExperience >= 500, playerExperience >= 1500, playerExperience >= 2500, playerExperience >= 3500, playerExperience >= 5000,
      totalStars >= 600 && playerExperience >= 5000
    };
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
    int[] stars = new int[40];
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

  public static void loadSettings() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Open(Application.persistentDataPath + "/settings.dat", FileMode.Open);
      
    Settings settings = (Settings)bf.Deserialize(file);
    isMusicSoundsOn = settings.music;
    isGameSoundsOn = settings.game;
    gridVisibility = settings.gridVisibility;

    file.Close();
  }

  public static void saveSettings() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/settings.dat");

    Settings settings = new Settings();
    settings.music = isMusicSoundsOn;
    settings.game = isGameSoundsOn;
    settings.gridVisibility = gridVisibility;

    bf.Serialize(file, settings);
    file.Close();
  }

  public static void loadPlayerDetails() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
      
    PlayerDetails player = (PlayerDetails)bf.Deserialize(file);
    playerExperience = player.experience;
    playerHints = player.hints;
    playerRank = player.rank;
    playerShip = player.ship;

    file.Close();
  }

  public static void savePlayerDetails() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/player.dat");

    PlayerDetails player = new PlayerDetails();
    player.experience = playerExperience;
    player.hints = playerHints;
    player.rank = playerRank;
    player.ship = playerShip;

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
public class Settings {
  public bool music;
  public bool game;
  public float gridVisibility;
}

[System.Serializable]
public class PlayerDetails {
  public int experience;
  public int hints;
  public string rank;
  public string ship;
}

[System.Serializable]
public class PuzzleScore {
  public int best;
  public int stars;
}