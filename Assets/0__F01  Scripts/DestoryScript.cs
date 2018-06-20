using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("EXDestroy", 1);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void EXDestroy (){
		Destroy (this.gameObject);
	}
}
