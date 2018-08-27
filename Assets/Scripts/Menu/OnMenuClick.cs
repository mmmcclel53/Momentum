using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class OnMenuClick : MonoBehaviour {

  public GameObject levelsList;
  public GameObject level;

	public void onDifficultyClick(string difficulty) {
    
    GameManager.setParam("difficulty", difficulty);

    // TODO: Remember to modify first level

    DirectoryInfo directory = new DirectoryInfo("Assets/Resources/Levels/");
		FileInfo[] files = directory.GetFiles("*.txt");
    int x=2;
    foreach (FileInfo file in files) {
      if (file.Name.Contains(difficulty)) {
        GameObject levelCopy = Instantiate(level, levelsList.transform);
        levelCopy.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Level " + x;
        x++;
      }
    }
	}

	public void onLevelsClick() {
		// Total stars per difficulty, from memory
    GameManager.setParam("gameType", "level");
	}

  public void onLevelClick() {
    // This is ghetto. Fix when possible.
    string level = this.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text.Replace("Level ","");
    GameManager.setParam("level", level);
		GameManager.Load("Game", GameManager.getSceneParameters());
  }
  
  public void onPlayClick() {
    GameManager.setParam("gameType", "play");
  }
}
