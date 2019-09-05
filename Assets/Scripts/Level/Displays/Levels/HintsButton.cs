using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HintsButton : MonoBehaviour {

  private SwipeManager swipeManager;
  private string[] solution = null;
  public GameObject[] movableObjects;  

  public void onHintClick() {

    if (MovingObject.getIsMoving() || GameManager.playerHints <= 0) {
      return;
    }

    GameManager.playerHints -= 1;
    GameManager.savePlayerDetails();

    if (solution == null) {
      solution = LevelManager.solution;
    }

    int movingObjectIndex = Mathf.FloorToInt(Int32.Parse(solution[0]) / 16);
    MovingObject.setObject(movableObjects[movingObjectIndex]);

    Swipe direction = getSwipeDirection(Int32.Parse(solution[0]) % 16);
    MovingObject.setSwipeDirection(direction);
    
    Vector3 currentPos = MovingObject.getObject().transform.position;
    Vector3 newPos = swipeManager.calculateNewPosition(currentPos, direction);
    MovingObject.setPosition(newPos);
    
    MovingObject.setIsMoving(true);

    Move move = new Move(MovingObject.getObject(), direction, currentPos, newPos);
    LevelManager.moves.Add(move);

    solution = solution.Skip(1).ToArray(); 
  }

  private Swipe getSwipeDirection(int direction) {
    switch (direction) {
      case 1:
        return Swipe.Up;
      case 2:
        return Swipe.Right;
      case 4:
        return Swipe.Down;
      case 8:
        return Swipe.Left;
      default:
        return Swipe.None;
    }
  }

  void Start() {
    if (GameManager.gameType == "ranked" || GameManager.gameType == "time_trials") {
      Destroy(this.gameObject);
      return;
    }
    GameObject grid = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "LevelGrid").First();
    swipeManager = grid.GetComponent<SwipeManager>();
  }

	void Update() {
    RectTransform parentRect = this.gameObject.transform.GetChild(1).gameObject.GetComponent<RectTransform>();    
		Text textComponent = this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
    textComponent.text = (GameManager.playerHints).ToString();
    parentRect.sizeDelta = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight) + new Vector2(10,10);
	}
}
