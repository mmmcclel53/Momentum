using CloudOnce;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
  
  public static string[] RANKS = new string[10] {"Novice", "Apprentice", "Adept", "Veteran", "Expert", "Elite", "Ace", "Legend", "Mythic", "Transcendent"};
  public static int[] RANK_XP = new int[10] {500, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000};

  public static string gameType = "levels";

  // Player
  public static int playerHints = 0;
  public static string playerShip = "ship1";

  // Ranked
  public static int rankedExperience = 500;
  public static string rankedTitle = "Novice";
  public static int bestRankedExperience = 500;

  // Levels
  public static int[] currentStars;
  public static int[] easyStars;
  public static int[] mediumStars;
  public static int[] hardStars;
  public static int[] masterStars;
  public static int[] impossibleStars;
  public static int totalStars = 0;

  // Time Trials
  public static int[] timeTrialsLevelsToUnlockReward = new int[6] {
    10, 15, // Easy
    5, 10, // Medium
    3, 5 // Hard
  };
  public static int timeTrialsEasy = 0;
  public static int timeTrialsMedium = 0;
  public static int timeTrialsHard = 0;

  public static int currentBest = 0;

  // Settings
  public static bool isMusicSoundsOn = true;
  public static bool isGameSoundsOn = true;
  public static float gridVisibility = 0.3f;

  public static bool[] shipUnlocks = {
    true, // Default Ship
    false, false, false, false, false, // Puzzle Ships
    false, false, false, false, false, // Ranked Ships
    false // 100% Ship
  };
  public static bool[] rewardUnlocks = {
    false, false, false, false, false, false
  };

  public static void Load(string sceneName) {
    SceneManager.LoadScene(sceneName);
  }

  private static string getNewRank() {
    for (int i=0; i<10; i++) {
      if (rankedExperience < RANK_XP[i]) {
        return RANKS[Math.Max(i-1, 0)];
      }
    }
    return "Transcendent";
  }

  public static void adjustRankedExperience(int adjustment) {
    if (rankedExperience + adjustment < 0) {
      rankedExperience = 0;
    } else {
      rankedExperience += adjustment;
    }
    rankedTitle = getNewRank();
  }

  public static void updateUnlocks() {
    const int PERFECT_STARS = 120;
    shipUnlocks = new bool[] {
      true, // Default Ship
      easyStars.Sum() == PERFECT_STARS, mediumStars.Sum() == PERFECT_STARS, hardStars.Sum() == PERFECT_STARS, masterStars.Sum() == PERFECT_STARS, impossibleStars.Sum() == PERFECT_STARS,
      bestRankedExperience >= 1000, bestRankedExperience >= 2000, bestRankedExperience >= 3000, bestRankedExperience >= 4000, bestRankedExperience >= 5000,
      totalStars >= 600 && bestRankedExperience >= 5000
    };

    rewardUnlocks = new bool[] {
      timeTrialsEasy >= timeTrialsLevelsToUnlockReward[0], timeTrialsMedium >= timeTrialsLevelsToUnlockReward[2], timeTrialsHard >= timeTrialsLevelsToUnlockReward[4],
      timeTrialsEasy >= timeTrialsLevelsToUnlockReward[1], timeTrialsMedium >= timeTrialsLevelsToUnlockReward[3], timeTrialsHard >= timeTrialsLevelsToUnlockReward[5]
    };
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
    playerHints = player.hints;
    playerShip = player.ship;

    file.Close();
  }

  public static void savePlayerDetails() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/player.dat");

    PlayerDetails player = new PlayerDetails();
    player.hints = playerHints;
    player.ship = playerShip;

    bf.Serialize(file, player);
    file.Close();
  }

  public static void loadRankedScore() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Open(Application.persistentDataPath + "/ranked.dat", FileMode.Open);
      
    RankedScore rankedScore = (RankedScore)bf.Deserialize(file);
    bestRankedExperience = rankedScore.best;
    rankedExperience = rankedScore.experience;
    rankedTitle = rankedScore.rank;

    file.Close();
  }

  public static void saveRankedScore() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/ranked.dat");

    RankedScore rankedScore = new RankedScore();
    rankedScore.experience = rankedExperience;
    rankedScore.rank = rankedTitle;

    if (rankedExperience > bestRankedExperience) {
      rankedScore.best = rankedExperience;
    }

    bf.Serialize(file, rankedScore);
    file.Close();

    // Achievements & Leaderboards
    if (rankedExperience >= 1000) {
      Achievements.ApprenticeRank.Unlock();
    }
    if (rankedExperience >= 1500) {
      Achievements.AdeptRank.Unlock();
    }
    if (rankedExperience >= 2000) {
      Achievements.VeteranRank.Unlock();
    }
    if (rankedExperience >= 2500) {
      Achievements.ExpertRank.Unlock();
    }
    if (rankedExperience >= 3000) {
      Achievements.EliteRank.Unlock();
    }
    if (rankedExperience >= 3500) {
      Achievements.AceRank.Unlock();
    }
    if (rankedExperience >= 4000) {
      Achievements.LegendRank.Unlock();
    }
    if (rankedExperience >= 4500) {
      Achievements.MythicRank.Unlock();
    }
    if (rankedExperience >= 5000) {
      Achievements.TranscendentRank.Unlock();
    }
    Leaderboards.RankedLeaderboard.SubmitScore(rankedExperience);
  }

  public static void loadStars() {
    easyStars = getStars("easy");
    mediumStars = getStars("medium");
    hardStars = getStars("hard");
    masterStars = getStars("master");
    impossibleStars = getStars("impossible");
  }

  // Total stars per difficulty, from memory
  private static int[] getStars(string difficulty) {
    int[] stars = new int[40];
    DirectoryInfo directory = new DirectoryInfo(Application.persistentDataPath);
    FileInfo[] files = directory.GetFiles("*.dat");
    BinaryFormatter bf = new BinaryFormatter();
    foreach (FileInfo f in files) {
      if (f.Name.Contains("levels_" + difficulty)) {
        FileStream file = File.Open(Application.persistentDataPath + "/" + f.Name, FileMode.Open);
        LevelScore levelScore = (LevelScore)bf.Deserialize(file);
        file.Close();

        int index = LevelUtility.calculateIndex(f.Name.Replace("levels_" + difficulty, "").Replace(".dat", "")) - 1;
        stars[index] = levelScore.stars;
      }
    }
    return stars;
  }

  public static void loadLevelCurrentBest() {
    try {
      FileStream file = File.Open(Application.persistentDataPath + "/levels_" + LevelManager.difficulty + LevelManager.level + ".dat", FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      
      LevelScore levelScore = (LevelScore)bf.Deserialize(file);
      currentBest = levelScore.best;
      file.Close();
    } catch {
      currentBest = 0;
    }
  }

  public static void saveLevelScore(int best, int stars) {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(
      Application.persistentDataPath + "/levels_" + LevelManager.difficulty + LevelManager.level + ".dat"
    );

    LevelScore levelScore = new LevelScore();
    levelScore.best = best;
    levelScore.stars = stars;

    bf.Serialize(file, levelScore);
    file.Close();
    
    // Achievements & Leaderboards
    if (totalStars >= 100) {
      Achievements.Stars100.Unlock();
    }
    if (totalStars >= 200) {
      Achievements.Stars200.Unlock();
    }
    if (totalStars >= 300) {
      Achievements.Stars300.Unlock();
    }
    if (totalStars >= 400) {
      Achievements.Stars400.Unlock();
    }
    if (totalStars >= 500) {
      Achievements.Stars500.Unlock();
    }
    if (totalStars >= 600) {
      Achievements.Stars600.Unlock();
    }
    Leaderboards.LevelsLeaderboard.SubmitScore(totalStars);
  }

  public static int loadTimeTrialsCurrentBest(string difficulty) {
    try {
      FileStream file = File.Open(Application.persistentDataPath + "/time_trials_" + difficulty + ".dat", FileMode.Open);
      BinaryFormatter bf = new BinaryFormatter();
      
      TimeTrialsScore timeTrialsScore = (TimeTrialsScore)bf.Deserialize(file);
      currentBest = timeTrialsScore.best;
      file.Close();
    } catch {
      currentBest = 0;
    }
    return currentBest;
  }

  public static void saveTimeTrialsBest(int best, string difficulty) {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(
      Application.persistentDataPath + "/time_trials_" + difficulty + ".dat"
    );

    TimeTrialsScore timeTrialsScore = new TimeTrialsScore();
    timeTrialsScore.best = best;

    bf.Serialize(file, timeTrialsScore);
    file.Close();

    // Achievements & Leaderboards
    if (difficulty == "easy") {
      if (best >= 15) {
        Achievements.Easy15TimeTrials.Unlock();
      }
      Leaderboards.TimeTrialsEasyLeaderboard.SubmitScore(best);
    } else if (difficulty == "medium") {
      if (best >= 10) {
        Achievements.Medium10TimeTrials.Unlock();
      }
      Leaderboards.TimeTrialsMediumLeaderboard.SubmitScore(best);
    } else if (difficulty == "hard") {
      if (best >= 5) {
        Achievements.Hard5TimeTrials.Unlock();
      }
      Leaderboards.TimeTrialsHardLeaderboard.SubmitScore(best);
    }

    timeTrialsEasy = loadTimeTrialsCurrentBest("easy");
    timeTrialsMedium = loadTimeTrialsCurrentBest("medium");
    timeTrialsHard = loadTimeTrialsCurrentBest("hard");

    if ((timeTrialsEasy + timeTrialsMedium + timeTrialsHard) >= 30) {
      Achievements.TimeTrials30.Unlock();
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
    public int hints;
    public string ship;
  }

  [System.Serializable]
  public class RankedScore {
    public int best;
    public int experience;
    public string rank;
  }

  [System.Serializable]
  public class LevelScore {
    public int best;
    public int stars;
  }

  [System.Serializable]
  public class TimeTrialsScore {
    public int best;
  }
}
