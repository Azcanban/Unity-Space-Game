using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	public float damage = 100;

	public void Hit(){
		Destroy (gameObject);
	}

	public float GetDamage(){
		return damage;
	}
}
