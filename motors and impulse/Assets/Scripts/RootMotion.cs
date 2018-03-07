using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RootMotion : MonoBehaviour {

	void OnAnimatorMove(){
		Animator animator = GetComponent<Animator> ();
		if(animator){
			Vector3 newPos = transform.position;
			newPos.z += animator.GetFloat ("Speed") * Time.deltaTime;
			newPos.x += animator.GetFloat ("Speed") * Time.deltaTime;

			transform.position = newPos;
		}
	}
}
