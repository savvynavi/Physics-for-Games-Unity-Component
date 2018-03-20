using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	//quits the app
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
