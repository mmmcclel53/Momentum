using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
  public static string gameType;  

  // TODO: Player class/object
  public static int playerExperience;
  public static string playerRank;

  public static int totalStars;
  public static int[] currentStars;
  public static int[] easyStars;
  public static int[] mediumStars;
  public static int[] hardStars;
  public static int[] masterStars;
  public static int[] impossibleStars;

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

  // Total stars per difficulty, from memory
  private static int[] getStars(string difficulty) {
    int[] stars = new int[75];
    DirectoryInfo directory = new DirectoryInfo(Application.persistentDataPath);
    FileInfo[] files = directory.GetFiles("*.dat");
    BinaryFormatter bf = new BinaryFormatter();
    foreach (FileInfo f in files) {
      if (f.Name.Contains(difficulty)) {
        FileStream file = File.Open(Application.persistentDataPath + "/" + f.Name, FileMode.Open);
        Stars starScore = (Stars)bf.Deserialize(file);
        file.Close();

        int index = LevelUtility.calculateIndex(f.Name.Replace(difficulty, "").Replace(".dat", "")) - 1;
        stars[index] = starScore.score;
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

  public static void saveStars(int score) {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(
      Application.persistentDataPath + "/" + LevelManager.difficulty + LevelManager.level + ".dat"
    );

    Stars stars = new Stars();
    stars.score = score;

    bf.Serialize(file, stars);
    file.Close();
  }
}

[System.Serializable]
public class PlayerDetails {
  public string rank;
  public int experience;
}

[System.Serializable]
public class Stars {
  public int score;
}