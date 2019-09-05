using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class UndoButton : MonoBehaviour {
  public Tilemap playersAndGoal;
  private Tile goal;

  public void onUndoClick() {
    if (LevelManager.moves.Count == 0) {
      return;
    }

    Move move = LevelManager.moves[LevelManager.moves.Count-1];
    MovingObject.setObject(move.movingObj);
    MovingObject.setSwipeDirection(move.swipeDirection);
    MovingObject.setPosition(move.start);
    MovingObject.setIsMoving(true);

    // Gross that this has to be in 2 places
    Vector3Int pos = playersAndGoal.WorldToCell(move.end);
    if (pos == LevelManager.goalTile) {
      playersAndGoal.SetTile(pos, goal);
    } else {
      playersAndGoal.SetTile(pos, null);
    }

    LevelManager.moves.RemoveAt(LevelManager.moves.Count-1);
  }

  void Start() {
    if (GameManager.gameType == "ranked" || GameManager.gameType == "time_trials") {
      Destroy(this.gameObject);
    }
    goal = Resources.Load <Tile> ("Tiles/Goal");
  }
}
