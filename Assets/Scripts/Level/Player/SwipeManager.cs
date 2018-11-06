﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public enum Swipe { None, Up, Down, Left, Right };

public class SwipeManager : MonoBehaviour {

  public GameObject shipObj;
  public float minSwipeLength = 5f;
  public float speed;

  public GameObject puzzleSolvedModal;
  public GameObject rankedSolvedModal;

  public Tilemap playersAndGoal;
  public Tilemap northTilemap;
  public Tilemap eastTilemap;
  public Tilemap southTilemap;
  public Tilemap westTilemap;

  private Tile northWall;
  private Tile eastWall;
  private Tile southWall;
  private Tile westWall;

  private Tile ship;
  private Tile asteroid;
  private Tile goal;

  private Vector2 firstClickPos;
  private Vector2 secondClickPos;

  private bool isTileShipOrAsteroid(TileBase tile) {
    return tile == ship || tile == asteroid;
  }

  private bool isCurrentShipObj() {
    return MovingObject.getObject() == shipObj;
  }

  private Vector3 calculateNewPosition(Swipe swipe) {

    TileBase playerTile;
    TileBase northTile;
    TileBase southTile;
    TileBase eastTile;
    TileBase westTile;

    Vector3Int pos = playersAndGoal.WorldToCell(this.gameObject.transform.position);
    Vector3Int newPos;

    playersAndGoal.SetTile(pos, null);

    bool newPositionFound = false;
    while (!newPositionFound) {
      switch (swipe) {
        case Swipe.Up:
          newPos = new Vector3Int(pos.x, pos.y+1, 0);
          northTile = northTilemap.GetTile(pos);
          southTile = southTilemap.GetTile(newPos);
          playerTile = playersAndGoal.GetTile(newPos);

          if (northTile == northWall || southTile == southWall || isTileShipOrAsteroid(playerTile)) {
            newPositionFound = true;
            break;
          }
          pos.y++;
          break;
        case Swipe.Down:
          newPos = new Vector3Int(pos.x, pos.y-1, 0);
          southTile = southTilemap.GetTile(pos);
          northTile = northTilemap.GetTile(newPos);
          playerTile = playersAndGoal.GetTile(newPos);

          if (northTile == northWall || southTile == southWall || isTileShipOrAsteroid(playerTile)) {
            newPositionFound = true;
            break;
          }
          pos.y--;
          break;

        case Swipe.Left:
          newPos = new Vector3Int(pos.x-1, pos.y, 0);
          westTile = westTilemap.GetTile(pos);
          eastTile = eastTilemap.GetTile(newPos);
          playerTile = playersAndGoal.GetTile(newPos);

          if (westTile == westWall || eastTile == eastWall || isTileShipOrAsteroid(playerTile)) {
            newPositionFound = true;
            break;
          }
          pos.x--;
          break;
        case Swipe.Right:
          newPos = new Vector3Int(pos.x+1, pos.y, 0);
          eastTile = eastTilemap.GetTile(pos);
          westTile = westTilemap.GetTile(newPos);
          playerTile = playersAndGoal.GetTile(newPos);

          if (westTile == westWall || eastTile == eastWall || isTileShipOrAsteroid(playerTile)) {
            newPositionFound = true;
            break;
          }
          pos.x++;
          break;
      }
    }
    return northTilemap.CellToWorld(pos);
  }

  private Swipe getSwipeDirection(Vector2 currentSwipe) {
    currentSwipe.Normalize();
    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
      return Swipe.Up;
    } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
      return Swipe.Down;
    } else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
      return Swipe.Left;
    } else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
      return Swipe.Right;
    }
    return Swipe.None;
  }

  public void OnMouseDown() {
    Vector3 pos = Input.mousePosition;
    firstClickPos = new Vector2(pos.x, pos.y);
  }

  public void OnMouseUp() {
    Vector3 pos = Input.mousePosition;
    secondClickPos = new Vector2(pos.x, pos.y);
    Vector2 currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);
    
    // Make sure it was a legit swipe, not a tap
    if (!MovingObject.getIsMoving() && currentSwipe.magnitude >= minSwipeLength) {
      Swipe swipe = getSwipeDirection(currentSwipe);
      MovingObject.setSwipeDirection(swipe);
      MovingObject.setIsMoving(true);
      MovingObject.setObject(this.gameObject);
      MovingObject.setPosition(calculateNewPosition(swipe));
      LevelManager.moves++;
    }
  }

  void Start() {
    northWall = Resources.Load <Tile> ("Tiles/NorthWall");
    southWall = Resources.Load <Tile> ("Tiles/SouthWall");
    eastWall = Resources.Load <Tile> ("Tiles/EastWall");
    westWall = Resources.Load <Tile> ("Tiles/WestWall");
    
    ship = Resources.Load <Tile> ("Tiles/Ship");
    asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    goal = Resources.Load <Tile> ("Tiles/Goal");

    // To avoid silly null check in update
    MovingObject.setObject(shipObj);
    MovingObject.setPosition(shipObj.transform.position);
  }

  void Update() {
    GameObject movingObj = MovingObject.getObject();
    Vector3 newPos = MovingObject.getPosition();
    if (movingObj == null) {
      return;
    }
    
    if (movingObj.transform.position == newPos) { // App crashed here!
      MovingObject.setIsMoving(false);
      Vector3Int tilePos = playersAndGoal.WorldToCell(newPos);
      
      // Winner!
      if (isCurrentShipObj() && playersAndGoal.GetTile(tilePos) == goal) {
        LevelManager.paused = true;
        if (GameManager.gameType == "ranked") {
          rankedSolvedModal.SetActive(true);
        } else {
          puzzleSolvedModal.SetActive(true);
        }
      }

      playersAndGoal.SetTile(tilePos, isCurrentShipObj() ? ship : asteroid);
    }
    movingObj.transform.position = Vector3.MoveTowards(movingObj.transform.position, newPos, speed * Time.deltaTime);
	}
}
