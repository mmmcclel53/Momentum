using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

  public float degreesPerSecond;
	
	// Update is called once per frame
	void Update() {
		this.gameObject.transform.Rotate(0, 0, degreesPerSecond * Time.deltaTime);
	}
}
