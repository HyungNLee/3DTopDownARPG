using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWall : MonoBehaviour {

	public float lifeSpan;
	void Start () {
		Destroy(gameObject, lifeSpan);
	}
}
