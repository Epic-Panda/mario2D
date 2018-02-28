using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private float MAX_LEFT = 0;

	[SerializeField]
	private float MAX_RIGHT = 33.19f;

	private float Z_POS = -10;
    public float speed = 4;


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 0, -10);
		if(player==null)
			player=GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
	}

    private void FollowPlayer()
    {
        float x = player.transform.position.x, y = player.transform.position.y;

        if (x < MAX_LEFT)
            x = 0;
        else if (x > MAX_RIGHT)
            x = MAX_RIGHT;

        transform.position = new Vector3(x, 0, Z_POS);
    }
}
