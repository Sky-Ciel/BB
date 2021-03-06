﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrial : MonoBehaviour {

	public GameObject bullet1;   //弾丸オブジェクトのプレファブ
	//public Transform muzzle;    //銃口の位置を取得する用
	public GameObject point1;
	//	public GameObject center;
	public float bulletSpeed = 20;
	public float minLimit = 50;
	public AudioSource gunSound_3;
	public GameObject EX;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("A", 0,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void EXDestroy (){
		Destroy (EX);
	}

	void A (){
		Instantiate (EX, point1.transform.position, Quaternion.identity);
		Invoke("EXDestroy",1);
		gunSound_3.Play ();
		GameObject b = GameObject.Instantiate (bullet1, point1.transform.position, Quaternion.identity) as GameObject;//GameObject型に変換する。
		//			center.transform.position = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		//銃口の前方にbulletSpeed分の力を加える。
		b.GetComponent<Rigidbody>().AddForce (point1.transform.forward * bulletSpeed);
	}
}
