using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed = 1f;
	public float padding = 1f;

	public float projectileRepeatRate = 0.2f;
	public float projectileSpeed = 0.3f;
	public GameObject laserPrefab;
	
	private float maxX, minX, maxY, minY;
	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		minX = camera.ViewportToWorldPoint (new Vector3(0,0,distance)).x + padding;
		maxX = camera.ViewportToWorldPoint (new Vector3(1,0,distance)).x - padding;

		minY = camera.ViewportToWorldPoint (new Vector3(0,0,distance)).y + padding;
		maxY = camera.ViewportToWorldPoint (new Vector3(0,1,distance)).y - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x - speed * Time.deltaTime, minX, maxX),
			                                 transform.position.y,transform.position.z);
			
		}
		if 
		(Input.GetKey (KeyCode.RightArrow)){
			transform.position = new Vector3(Mathf.Clamp( transform.position.x + speed * Time.deltaTime, minX, maxX),
			                                 transform.position.y,transform.position.z);
		}
		if
		(Input.GetKey (KeyCode.UpArrow)) {
			transform.position = new Vector3(transform.position.x,
			                                 Mathf.Clamp(transform.position.y + speed * Time.deltaTime, minY, maxY),
			                                 transform.position.z);
			
		}
		if
		(Input.GetKey (KeyCode.DownArrow)) {
			transform.position = new Vector3(transform.position.x,
			                                 Mathf.Clamp(transform.position.y - speed * Time.deltaTime, minY, maxY),
			                                 transform.position.z);
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire", 0.00001f, projectileRepeatRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}

	void Fire(){
		GameObject beam = Instantiate (laserPrefab, transform.position,
		                               Quaternion.identity) as GameObject;
		
		beam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, projectileSpeed, 0);
	}
}
