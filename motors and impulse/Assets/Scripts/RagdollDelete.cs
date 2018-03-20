using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDelete : MonoBehaviour {
	public float delay;
	private void OnTriggerEnter(Collider other) {
		//Ragdoll ragdoll = other.gameObject.GetComponent<Ragdoll>();
		//if() {

		//}
		if(other.gameObject.tag == "FallingRobots") {
			Destroy(other.transform.root.gameObject, delay);
		}
	}
}
