using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicking : MonoBehaviour {

    Camera camera = null;
	Ray ray;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			ray = camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy"){
				Ragdoll ragdoll = hit.transform.GetComponentInParent<Ragdoll>();
				if (ragdoll != null){
					ragdoll.RagdollOn = true;
				}
			}
		}

	}
}
