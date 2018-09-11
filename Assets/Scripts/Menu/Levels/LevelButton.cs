using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelButton : UIBehaviour, Mosframe.IDynamicScrollViewItem {

  // Kinda gross
  private string calculateLevel(int level) {
    int prefix = Convert.ToInt32(Math.Floor((double)(level-1) / 15));
    int suffix = (level-1) % 15 + 1;
    switch (GameManager.difficulty) {
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

  private int[] getStarsArray() {
    switch (GameManager.difficulty) {
      case "easy":
        return GameManager.easyStars;
      case "medium":
        return GameManager.mediumStars;
      case "hard":
        return GameManager.hardStars;
      case "master":
        return GameManager.masterStars;
      case "impossible":
        return GameManager.impossibleStars;
      default:
        return GameManager.easyStars;
    }
  }

  public void onLevelClick() {
    // This is ghetto. Fix when possible.
    string level = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text.Replace("Level ","");
    GameManager.level = calculateLevel(Int32.Parse(level));
		GameManager.Load("Game");
  }

  public void onUpdateItem(int index) {
    Debug.Log(index);
    // Set Level text
    GameObject itemTextContainer = this.gameObject.transform.GetChild(0).gameObject;
    itemTextContainer.GetComponent<Text>().text = "Level " + (index+1);

    // Set Stars icons
    Transform itemStarContainer = this.gameObject.transform.GetChild(1).gameObject.transform;
    int[] starsArray = getStarsArray();
    if (starsArray[index] > 0) {
      for (int i=0; i<starsArray[index]; i++) {
        itemStarContainer.GetChild(i).gameObject.SetActive(true);
      }
    } else {
      for (int i=0; i<3; i++) {
        itemStarContainer.GetChild(i).gameObject.SetActive(false);
      }
    }
  }
}
