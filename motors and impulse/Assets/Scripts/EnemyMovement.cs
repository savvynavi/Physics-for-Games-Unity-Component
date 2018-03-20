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
	}

	// Update is called once per frame
	void Update () {
		//won't track player if dead/particle burst
		if (ragdoll && ragdoll.RagdollOn){
			agent.velocity = new Vector3(0, 0, 0);
			agent.updateRotation = false;
			if(isDead == false) {
				particles.Emit(30);
				isDead = true;
			}
			return;
		}

		
	}

	void FixedUpdate(){
		agent.destination = destination.position;
		if(Vector3.Distance(transform.position, destination.position) < agent.stoppingDistance){
			animator.SetFloat("Speed", 0);
		} else{
			animator.SetFloat("Speed", speed * Time.deltaTime);
		}
	}
}
