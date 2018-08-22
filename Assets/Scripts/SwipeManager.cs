using UnityEngine;

public enum Swipe { None, Up, Down, Left, Right };

public class SwipeManager : MonoBehaviour {
  public float minSwipeLength = 5f;
  Vector2 firstPressPos;
  Vector2 secondPressPos;
  Vector2 currentSwipe;

  Vector2 firstClickPos;
  Vector2 secondClickPos;
    
  public bool isStarMoving;
  public static Swipe swipeDirection;

  public void Update() {
    detectSwipe();
  }

  public void detectSwipe () {
    // Touch
    if (Input.touches.Length > 0) {
      Touch t = Input.GetTouch(0);
      
      if (t.phase == TouchPhase.Began) {
        firstPressPos = new Vector2(t.position.x, t.position.y);
      }
      
      if (t.phase == TouchPhase.Ended) {
        secondPressPos = new Vector2(t.position.x, t.position.y);
        currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        
        swipeDirection = getSwipeDirection();
      }
    } 

    // Click
    else {
      if (Input.GetMouseButtonDown(0)) {
        firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
      } else {
        swipeDirection = Swipe.None;
      }
      if (Input.GetMouseButtonUp (0)){
        secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

        swipeDirection = getSwipeDirection();
      }
    }
  }

  private Swipe getSwipeDirection() {
    // Make sure it was a legit swipe, not a tap
    if (currentSwipe.magnitude < minSwipeLength) {
      return Swipe.None;
    }
    
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
}
