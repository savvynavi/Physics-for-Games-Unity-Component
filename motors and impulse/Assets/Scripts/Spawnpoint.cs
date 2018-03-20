using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour {
	public GameObject spawnObj;
	public float spawnTime;
	float timer;
	// Use this for initialization
	void Start () {
		Instantiate(spawnObj, transform.position, transform.rotation);
		timer = Time.time + spawnTime;
	}

	// Update is called once per frame
	void Update () {
		if(timer < Time.time) {
			Instantiate(spawnObj, transform.position, transform.rotation);
			timer = Time.time + spawnTime;
		}
	}
}
