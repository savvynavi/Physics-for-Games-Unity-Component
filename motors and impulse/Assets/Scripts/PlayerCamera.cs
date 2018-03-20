using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	public Transform m_player;
	public float m_x, m_y, m_z;

	// Update is called once per frame
	void Update () {
		if(m_player != null) {
			//follows player, no rotation yet
			transform.position = new Vector3(m_player.position.x + m_x, m_player.position.y + m_y, m_player.position.z + m_z);
		}
	}
}
