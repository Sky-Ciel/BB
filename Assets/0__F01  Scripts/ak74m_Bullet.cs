using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ak74m_Bullet : MonoBehaviour {

	public GameObject bullet1;   //弾丸オブジェクトのプレファブ
	//public Transform muzzle;    //銃口の位置を取得する用
	public GameObject point1;
	//	public GameObject center;
	public float bulletSpeed = 300;
	public float minLimit = 50;
	public AudioSource gunSound_3;
	public GameObject EX;

	//このオブジェクト(Bullet)が生成された瞬間に実行される。
	void Start(){

	}

	//何かにぶつかったら実行される。(hit変数内に当たったオブジェクトに関する情報が代入されている。)
	void OnTriggerEnter(Collider hit){
		//このオブジェクト(弾丸)を削除する。
		Destroy(gameObject);

	}
	// Update is called once per frame
	void Update () {
		//		Vector3 nowSpeed = rigidbody.velocity;

		//現在の速度が指定値以下になったら
		//		if (nowSpeed.sqrMagnitude <= minLimit) {
		//			Destroy (gameObject);
		//		}

		if (Input.GetKeyDown(KeyCode.F)){
			Instantiate (EX, point1.transform.position, Quaternion.identity);
			gunSound_3.Play ();
			GameObject b = GameObject.Instantiate (bullet1, point1.transform.position, Quaternion.identity) as GameObject;//GameObject型に変換する。
//			center.transform.position = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
			//銃口の前方にbulletSpeed分の力を加える。
			b.GetComponent<Rigidbody>().AddForce (point1.transform.forward * bulletSpeed);
		}


	}

	void OnCollisionEnter(Collision hit){

		//このオブジェクト(弾丸)を削除する。
		Destroy(gameObject);

		//もし当たったオブジェクトがEnemyタグである(＝敵である)場合は、敵のDamage関数を実行する。
		if(hit.gameObject.tag == "Enemy"){
			//Damage関数を実行させる。
			Debug.Log(1);
			hit.collider.SendMessage("Damage");
		}
	}

}