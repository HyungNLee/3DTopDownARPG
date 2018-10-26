using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour {

  public float projectileSpeed;
  public float lifeSpan;

	void Start () 
  {
		GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;

    Destroy(gameObject, lifeSpan);
  }
}
