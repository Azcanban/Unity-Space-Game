using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}
}
