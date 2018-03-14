using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePicking : MonoBehaviour {

    Camera camera = null;
	Ray ray;
	public GameObject box;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
		//box.GetComponent<>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			ray = camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				Instantiate(box, hit.transform);
			}
		}

	}

	//private void FixedUpdate(){
	//	RaycastHit hit;
	//	bool castHit = Physics.Raycast(ray.origin, ray.direction * 10, out hit);
	//	if(castHit && Input.GetMouseButton(0)){
	//		//create object
	//		Instantiate(box);
			
	//	}
	//}
}
