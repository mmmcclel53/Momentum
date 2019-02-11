using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public enum Swipe { None, Up, Down, Left, Right };

public class SwipeManager : MonoBehaviour {

  public float minSwipeLength = 5f;

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

  private Vector2 startPos;
  private Vector2 endPos;
  private GameObject selectedObj;

  private bool isTileShipOrAsteroid(TileBase tile) {
    return tile == ship || tile == asteroid;
  }

  public Vector3 calculateNewPosition(Vector3 currentPos, Swipe direction) {

    TileBase playerTile;
    TileBase northTile;
    TileBase southTile;
    TileBase eastTile;
    TileBase westTile;

    Vector3Int pos = playersAndGoal.WorldToCell(currentPos);
    Vector3Int newPos;

    if (pos == LevelManager.goalTile) {
      playersAndGoal.SetTile(pos, goal);
    } else {
      playersAndGoal.SetTile(pos, null);
    }

    bool newPositionFound = false;
    while (!newPositionFound) {
      switch (direction) {
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
        default:
          newPositionFound = true;
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

  private void disableHints() {
    GameObject hintButton = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "HintsButton").First();
    
    Color color = hintButton.GetComponent<Image>().color;
    color.a = 0.5f;
    hintButton.GetComponent<Image>().color = color;

    color = hintButton.transform.GetChild(0).gameObject.GetComponent<Image>().color;
    color.a = 0.5f;
    hintButton.transform.GetChild(0).gameObject.GetComponent<Image>().color = color;

    color = hintButton.transform.GetChild(1).gameObject.GetComponent<Text>().color;
    color.a = 0.5f;
    hintButton.transform.GetChild(1).gameObject.GetComponent<Text>().color = color;

    color = hintButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color;
    color.a = 0.5f;
    hintButton.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = color;

    Destroy(hintButton.GetComponent<HintsButton>());
  }

  void Start() {
    northWall = Resources.Load <Tile> ("Tiles/NorthWall");
    southWall = Resources.Load <Tile> ("Tiles/SouthWall");
    eastWall = Resources.Load <Tile> ("Tiles/EastWall");
    westWall = Resources.Load <Tile> ("Tiles/WestWall");
    
    ship = Resources.Load <Tile> ("Tiles/Ship");
    asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    goal = Resources.Load <Tile> ("Tiles/Goal");
  }

  void Update() {
    if (Input.touches.Length > 0 && !LevelManager.solved && !LevelManager.paused && !MovingObject.getIsMoving()) {
      Touch touch = Input.GetTouch(0);
      Vector3 screenPoint = new Vector3(touch.position.x, touch.position.y, -Camera.main.transform.position.z);
      Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(screenPoint);
      Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
      RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

      // Selected object has not been set (could add highlighter here)
      if (selectedObj == null && hitInformation.collider != null) {
        selectedObj = hitInformation.transform.gameObject;
        // Held Swipe Effect
        // selectedObj.transform.localScale = LevelUtility.calculateShipTouchScaleSize();
      }

      // Detect swipe direction
      if (touch.phase == TouchPhase.Began) {
        startPos = touch.position;
      }
      if (touch.phase == TouchPhase.Ended) {
        endPos = touch.position;
      }

      // Held Swipe Effect
      Vector2 heldSwipe = new Vector3(touch.position.x - startPos.x, touch.position.y - startPos.y);
      if (selectedObj != null && heldSwipe.magnitude >= minSwipeLength) {
        Swipe direction = getSwipeDirection(heldSwipe);
        MovingObject.setSwipeDirection(direction);
        MovingObject.setPosition(selectedObj.transform.position);
        MovingObject.setObject(selectedObj);
      }

      if (startPos == new Vector2(0, 0) || endPos == new Vector2(0, 0)) {
        return;
      }

      // Make sure it was a legit swipe and on a movable game object
      Vector2 currentSwipe = new Vector3(endPos.x - startPos.x, endPos.y - startPos.y);
      startPos = new Vector2(0, 0);
      endPos = new Vector2(0, 0);

      if (selectedObj != null && currentSwipe.magnitude >= minSwipeLength) {
        // Held Swipe Effect
        // selectedObj.transform.localScale = new Vector3(0.8f, 0.8f, 1);

        Swipe direction = getSwipeDirection(currentSwipe);

        // If invalid swipe, return
        if ( !(direction == Swipe.Up || direction == Swipe.Down || direction == Swipe.Left || direction == Swipe.Right) ) {
          return;
        }

        // If the player has moved, hints should be disabled
        if (GameManager.gameType == "levels") {
          disableHints();
        }

        MovingObject.setObject(selectedObj);
        MovingObject.setSwipeDirection(direction);

        Vector3 currentPos = MovingObject.getObject().transform.position;
        Vector3 newPos = calculateNewPosition(currentPos, direction);

        // Only increase counter if new location
        if (currentPos != newPos) {
          LevelManager.moves++;
        }

        MovingObject.setPosition(newPos);
        MovingObject.setIsMoving(true);
        selectedObj = null;
      }
      
      // Held Swipe Effect
      // else if (selectedObj != null && currentSwipe.magnitude <= minSwipeLength) {
      //   selectedObj.transform.localScale = new Vector3(0.8f, 0.8f, 1);
      //   selectedObj = null;
      // }
    }
  }
}
