using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

  // Movement speed of character
  // SerializeField lets the class be public but show up in editor.
  [SerializeField]
  protected float speed;
  [SerializeField]
  protected Rigidbody rb;

  // State controller/
  protected enum CharacterState {Ready, Dashing};
  protected CharacterState currentState;

  // Direction of character.
  // 'Protected' means everything that inhertits from this script can access it.
  protected Vector3 direction;

  // Dashing variables.
  public float dashSpeed;
  private float dashTime;
  public float startDashTime;
    // Use dashDirection so user can't change dash direction mid-dash.
  private Vector3 dashDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    currentState = CharacterState.Ready;

    // Dash time
    dashTime = startDashTime;
	}
	
	// Update is called once per frame
  // Made this 'virtual' so the script that inherits from this class can override this Update() method.
	protected virtual void Update () {
    // For some reason the Start() fails to grab rigidbody component at times.
    if (rb == null)
    {
      rb = GetComponent<Rigidbody>();
    }

    // Let's player control movement when in ready state;
    if (currentState == CharacterState.Ready)
    {
      Move();
    }

    // Dashing loop
    if (currentState == CharacterState.Dashing)
    {
      Dash();
    }
	}

  // Moves the player according to input from GetInput().
  public void Move()
  {
    rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
  }

  public void StartDash()
  {
    if (currentState == CharacterState.Ready)
    {
      currentState = CharacterState.Dashing;
      dashDirection = direction;
    }
  }

  // Dashes the character in the direction the character is moving.
  // * Will probably need to rewrite this dash function to take into account the character's rotation instead of Vector2.direction.
  public void Dash()
  {
    if (dashTime <= 0)
    {
      currentState = CharacterState.Ready;
      dashTime = startDashTime;
      rb.velocity = Vector2.zero;
    }
    else
    {
      dashTime -= Time.deltaTime;
      rb.velocity = dashDirection * dashSpeed;
    }
  }
}
