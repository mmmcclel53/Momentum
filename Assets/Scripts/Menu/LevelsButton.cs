using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButton : MonoBehaviour {

  // Change levels to 1-75 index. Delete this later.
  private int calculateIndex(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    // Impossible difficulty
    if (complexity >= 20) {
      return number;
    }

    // Mega gross
    return ((complexity % 5) * 15) + number;
  }

  // Total stars per difficulty, from memory
  private int[] getStars(string difficulty) {
    int[] stars = new int[75];
    DirectoryInfo directory = new DirectoryInfo(Application.persistentDataPath);
    FileInfo[] files = directory.GetFiles("*.dat");
    BinaryFormatter bf = new BinaryFormatter();
    foreach (FileInfo f in files) {
      if (f.Name.Contains(difficulty)) {
        FileStream file = File.Open(Application.persistentDataPath + "/" + f.Name, FileMode.Open);
        Stars starScore = (Stars)bf.Deserialize(file);
        file.Close();

        int index = calculateIndex(f.Name.Replace(difficulty, "").Replace(".dat", "")) - 1;
        stars[index] = starScore.score;
      }
    }
    return stars;
  }

  public void onLevelsClick() {
    GameManager.easyStars = getStars("easy");
    GameManager.mediumStars = getStars("medium");
    GameManager.hardStars = getStars("hard");
    GameManager.masterStars = getStars("master");
    GameManager.impossibleStars = getStars("impossible");
    GameManager.gameType = "level";
  }
}
