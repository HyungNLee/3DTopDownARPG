using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

  public GameObject spellOne;
  public GameObject spellOneLaunchPoint;

	// Use this for initialization
	void Start () 
  {
		speed = 25f;
    dashSpeed = 50f;
    startDashTime = 0.1f;
	}
	
	// Update is called once per frame
  // Wrote 'override' so this class can override the Update() in the character script.
	protected override void Update () 
  {
    if (rb == null)
    {
      rb = GetComponent<Rigidbody>();
    }
		GetInput();
    Turning();

    // base means to access the script that this player script inherits from. In this case, the character script.
    base.Update();
	}

  private void GetInput()
  {
    direction = Vector2.zero;
    
    // Directional inputs.
    if (Input.GetKey(KeyCode.W)) {
      direction += Vector3.forward;
    }
    if (Input.GetKey(KeyCode.A)) {
      direction += Vector3.left;
    }
    if (Input.GetKey(KeyCode.S)) {
      direction += Vector3.back;
    }
    if (Input.GetKey(KeyCode.D)) {
      direction += Vector3.right;
    }
    direction.Normalize();

    // Dash input.
    if (Input.GetKeyDown(KeyCode.Space))
    {
      base.StartDash();
    }

    // Right click spell
    if (Input.GetMouseButtonDown(1))
    {
      castSpellOne();
    }
  }

  // Function to make player rotate to mouse.
  private void Turning()
  {
    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit floorHit;

    if (Physics.Raycast (camRay, out floorHit, 100f))
    {
      Vector3 playerToMouse = floorHit.point - transform.position;
      playerToMouse.y = 0f;

      Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
      rb.MoveRotation(newRotation);
    }
  }

  // Spell One Function.
  private void castSpellOne()
  {
    if (currentState == CharacterState.Ready)
    {

    }
  }
}
