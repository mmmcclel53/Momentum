using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	public void togglePause() {
    LevelManager.pause = !LevelManager.pause;
  }
}
