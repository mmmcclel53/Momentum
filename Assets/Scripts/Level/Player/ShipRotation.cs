using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class ShipRotation : MonoBehaviour {
  
  public Tilemap playersAndGoal;

  private Vector3 rotationVector;

  void Start() {
    this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(("Ships/" + GameManager.playerShip).ToString());
    rotationVector = this.gameObject.transform.rotation.eulerAngles;
    MovingObject.setSwipeDirection(Swipe.Up);
  }

	// Update is called once per frame
	void Update() {
		if (MovingObject.getObject() == this.gameObject) {
      switch (MovingObject.getSwipeDirection()) {
        case Swipe.Down:
          rotationVector.z = 0f;
          break;
        case Swipe.Right:
          rotationVector.z = 90f;
          break;
        case Swipe.Up:
          rotationVector.z = 180f;         
          break;
        case Swipe.Left:
          rotationVector.z = 270f;
          break;
      }
      this.gameObject.transform.rotation = Quaternion.Euler(rotationVector);
    }
	}
}
