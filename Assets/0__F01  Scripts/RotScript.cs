﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (player.transform);
	}
}
