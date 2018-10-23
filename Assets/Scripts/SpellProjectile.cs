using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * 40;

    Destroy(gameObject, 3.0f);
	}
	
	// // Update is called once per frame
	// void Update () {
		
	// }
}
