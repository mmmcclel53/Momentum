using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour {

  public float movementForce;
  public SwipeManager SwipeManager;
  private Swipe swipeDirection = Swipe.None;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    swipeDirection = SwipeManager.swipeDirection;
		if (swipeDirection != Swipe.None) {
      rb2d.bodyType = RigidbodyType2D.Dynamic;
      switch(swipeDirection) {
        case Swipe.Up:
          rb2d.AddForce(new Vector2(0f, movementForce), ForceMode2D.Impulse);
          break;
        case Swipe.Down:
          rb2d.AddForce(new Vector2(0f, -movementForce), ForceMode2D.Impulse);
          break;
        case Swipe.Right:
          rb2d.AddForce(new Vector2(movementForce, 0f), ForceMode2D.Impulse);
          break;
        case Swipe.Left:
          rb2d.AddForce(new Vector2(-movementForce, 0f), ForceMode2D.Impulse);
          break;
      }
    }
	}

  void OnCollisionEnter2D(Collision2D collision) {
    rb2d.bodyType = RigidbodyType2D.Kinematic;
    Debug.Log("stop");
  }
}
