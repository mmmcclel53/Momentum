using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButton : MonoBehaviour {
  public void onLevelsClick() {
		// Total stars per difficulty, from memory
    GameManager.setParam("gameType", "level");
  }
}
