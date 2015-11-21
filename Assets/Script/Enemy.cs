using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 150;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collision){
		Projectile missle = collision.gameObject.GetComponent<Projectile> (); // game object colliding with
		if (missle) {
			health -= missle.GetDamage();
			missle.Hit();
			if(health <= 0){
				Destroy(gameObject);
			}
		}
	}
}
