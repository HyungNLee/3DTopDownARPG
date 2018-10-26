using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
// *Need to move spell variables and scripts to master spell script.
  // Right click spell variables
  public GameObject rightClickProjectile;
  public GameObject rightClickLaunchPoint;
  // 'Q' spell variables
  public GameObject qSpellProjectile;

	// Use this for initialization
	void Start () 
  {
		speed = 10f;
    dashSpeed = 30f;
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
    direction = Vector3.zero;
    
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
      castRightClickSpell();
    }

    // 'Q' spell
    if (Input.GetKeyDown(KeyCode.Q))
    {
      castQSpell();
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

  // Right click spell function.
  private void castRightClickSpell()
  {
    if (currentState == CharacterState.Ready)
    {
      GameObject spell = Instantiate(rightClickProjectile, rightClickLaunchPoint.transform.position, rightClickLaunchPoint.transform.rotation);
    }
  }

  // 'Q' spellcast function
  private void castQSpell()
  {
    Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit floorHit;

    if (currentState == CharacterState.Ready && Physics.Raycast (camRay, out floorHit, 100f))
    {
      GameObject spell = Instantiate(qSpellProjectile, floorHit.point, rightClickLaunchPoint.transform.rotation);
    }
  }
}
