using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.IO;

public class LevelManager : MonoBehaviour {

  public GameObject shipObj;
  public Tilemap playersAndGoal;

  // Speed in units per sec.
  public float speed;

  private Tile ship;
  private Tile asteroid;
  private Tile goal;
  private GameObject movingObj;
  private Vector3 newPos;

  private bool isCurrentShipObj() {
    return MovingObject.getObject() == shipObj;
  }

  // To avoid silly check in Update
  void Start() {
    MovingObject.setObject(shipObj);
    MovingObject.setPosition(shipObj.transform.position);

    ship = Resources.Load <Tile> ("Tiles/Ship");
    asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    goal = Resources.Load <Tile> ("Tiles/Goal");
  }

	// Update is called once per frame
	void Update() {
    movingObj = MovingObject.getObject();
    newPos = MovingObject.getPosition();
    if (movingObj.transform.position == newPos) {
      MovingObject.setIsMoving(false);
      Vector3Int tilePos = playersAndGoal.WorldToCell(newPos);
      
      // Winner!
      if (isCurrentShipObj() && playersAndGoal.GetTile(tilePos) == goal) {
        Debug.Log("success!");
      }

      playersAndGoal.SetTile(tilePos, isCurrentShipObj() ? ship : asteroid);
    }
    movingObj.transform.position = Vector3.MoveTowards(movingObj.transform.position, newPos, speed * Time.deltaTime);
	}
}
