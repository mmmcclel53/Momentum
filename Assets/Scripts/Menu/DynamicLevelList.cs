using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLevelList : MonoBehaviour {

  public GameObject scrollRectContainer;

  // Gross...
	void Update () {
    float scrollPos = scrollRectContainer.GetComponent<ScrollRect>().verticalNormalizedPosition;
    Debug.Log(scrollPos);
    for (int i=0; i<10; i++) {
	  	this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
	}
}
