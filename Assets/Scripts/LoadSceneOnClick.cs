using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneOnClick : MonoBehaviour {

	public void onBeginnerClick() {
		GameManager.Load("Game", "difficulty", "beginner");
	}
}
