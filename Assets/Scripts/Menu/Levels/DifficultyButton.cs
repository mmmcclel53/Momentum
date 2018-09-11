using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

  public GameObject levelsScrollView;

  public void onDifficultyClick(string difficulty) {
    GameManager.difficulty = difficulty;
    DirectoryInfo directory = new DirectoryInfo("Assets/Resources/Levels/Puzzles/" + difficulty);
		FileInfo[] files = directory.GetFiles("*.txt");
    levelsScrollView.GetComponent<Mosframe.DynamicVScrollView>().totalItemCount = files.Length;
	}
}
