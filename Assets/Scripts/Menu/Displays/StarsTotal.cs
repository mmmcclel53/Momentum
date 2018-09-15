using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StarsTotal : MonoBehaviour {
	void Update () {
    int starsTotal = GameManager.easyStars.Sum() + GameManager.mediumStars.Sum() + GameManager.hardStars.Sum() + GameManager.masterStars.Sum() + GameManager.impossibleStars.Sum();
    this.gameObject.GetComponent<Text>().text = starsTotal.ToString();
	}
}
