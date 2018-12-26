using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsTotal : MonoBehaviour {
	void Update () {
    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = GameManager.totalStars.ToString();
	}
}
