using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;


public class OnMenuClick : MonoBehaviour {

  public GameObject levelsList;
  public GameObject level;

	public void onDifficultyClick(string difficulty) {
    
    GameManager.setParam("difficulty", difficulty);

    // TODO: Remember to modify first level

    DirectoryInfo directory = new DirectoryInfo("Assets/Resources/Levels/Puzzles/");
		FileInfo[] files = directory.GetFiles("*.txt");
    int x=2;
    foreach (FileInfo file in files) {
      if (file.Name.Contains(difficulty)) {
        GameObject levelCopy = Instantiate(level, levelsList.transform);
        levelCopy.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Level " + x;
        levelCopy.SetActive(false);
        x++;
      }
    }
	}

	public void onLevelsClick() {
		// Total stars per difficulty, from memory
    GameManager.setParam("gameType", "level");
	}

  // Kinda gross
  private string calculateLevel(string level) {
    int prefix = Convert.ToInt32(Math.Floor((double)Int32.Parse(level)/15));
    string suffix = (Int32.Parse(level)%15 + 1).ToString();
    switch (GameManager.getParam("difficulty")) {
      case "easy":
        return prefix.ToString() + "_" + suffix;
      case "medium":
        return (prefix+5).ToString() + "_" + suffix;
      case "hard":
        return (prefix+10).ToString() + "_" + suffix;
      case "master":
        return (prefix+15).ToString() + "_" + suffix;
      case "impossible":
        return "20_" + level;
      default:
        return prefix.ToString() + "_" + suffix;
    }
  }

  public void onLevelClick() {
    // This is ghetto. Fix when possible.
    string level = this.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text.Replace("Level ","");
    GameManager.setParam("level", calculateLevel(level));
		GameManager.Load("Game", GameManager.getSceneParameters());
  }
  
  public void onMainMenuClick() {
    GameManager.Load("MainMenu");
  }

  public void onPlayClick() {
    GameManager.setParam("gameType", "play");
  }

  public void onRestartClick() {
    GameManager.Load(SceneManager.GetActiveScene().name);
  }
}
