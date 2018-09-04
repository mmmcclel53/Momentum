using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelButton : UIBehaviour, Mosframe.IDynamicScrollViewItem {

  // Kinda gross
  private string calculateLevel(int level) {
    int prefix = Convert.ToInt32(Math.Floor((double)(level-1) / 15));
    int suffix = (level-1) % 15 + 1;
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
    GameManager.setParam("level", calculateLevel(Int32.Parse(level)));
		GameManager.Load("Game", GameManager.getSceneParameters());
  }

  public void onUpdateItem(int index) {
    Debug.Log(index);
    this.gameObject.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text = "Level " + (index+1);
  }
}
