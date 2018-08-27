using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

  public float time = 0f;
	
	// Update is called once per frame
	void Update() {
		time += Time.deltaTime;
    int minutes = Mathf.FloorToInt(time / 60F);
    int seconds = Mathf.FloorToInt(time - minutes * 60);     
    this.gameObject.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    GameManager.setParam("time", time.ToString());
	}
}
