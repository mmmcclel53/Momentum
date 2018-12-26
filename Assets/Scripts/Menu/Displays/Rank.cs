using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour {
	void Update () {
    Sprite icon = Resources.Load <Sprite> (("Ranks/" + GameManager.playerRank).ToString());
    this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.playerRank;
	}
}
