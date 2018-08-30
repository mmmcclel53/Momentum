using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	void Start () {
		switch(GameManager.getParam("difficulty")) {
      case "easy":
        Sprite easyBG = Resources.Load <Sprite> ("Backgrounds/EasyBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = easyBG;
        break;
      case "medium":
        Sprite mediumBG = Resources.Load <Sprite> ("Backgrounds/MediumBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = mediumBG;
        break;
      case "hard":
        Sprite hardBG = Resources.Load <Sprite> ("Backgrounds/HardBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hardBG;
        break;
      case "master":
        Sprite masterBG = Resources.Load <Sprite> ("Backgrounds/MasterBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = masterBG;
        break;
      case "impossible":
        Sprite impossibleBG = Resources.Load <Sprite> ("Backgrounds/ImpossibleBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = impossibleBG;
        break;
      default:
        Sprite easyBG = Resources.Load <Sprite> ("Backgrounds/EasyBackground");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = easyBG;
        break;
    }
	}
}
