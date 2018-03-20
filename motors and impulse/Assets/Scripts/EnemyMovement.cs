using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour {

	NavMeshAgent agent = null;
	Animator animator = null;
	Ragdoll ragdoll = null;
	ParticleSystem particles = null;
	public float speed = 80.0f;
	//public float buffer = 2.0f;
	public Transform destination;
	public ParticleSystem particle;
	bool isDead;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		ragdoll = GetComponent<Ragdoll>();
		particles = GetComponent<ParticleSystem>();
		isDead = false;
		//particle = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update () {
		//won't track player if dead
		if (ragdoll && ragdoll.RagdollOn){
			agent.velocity = new Vector3(0, 0, 0);
			if(isDead == false) {
				particles.Emit(30);
				isDead = true;
			}
			return;
		}

		animator.SetFloat("Speed", speed * Time.deltaTime);
		agent.destination = destination.position;
	}

	void FixedUpdate(){
		//agent.Move(agent.destination);
	}
}
