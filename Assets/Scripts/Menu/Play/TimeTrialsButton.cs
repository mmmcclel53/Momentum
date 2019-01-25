using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialsButton : MonoBehaviour {
  public void onTimeTrialsClick() {
    GameManager.gameType = "time_trials";
  }
}
