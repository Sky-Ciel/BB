using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript_of_theAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision hit){

		//このオブジェクト(弾丸)を削除する。
//		Debug.Log(hit.gameObject);

		//もし当たったオブジェクトがEnemyタグである(＝敵である)場合は、敵のDamage関数を実行する。
		if (hit.gameObject.tag == "Destructible objects") {
			Destroy (hit.gameObject);
		}else if(hit.gameObject.tag == "Enemy"){
			hit.collider.SendMessage("Damage");
		}

		Destroy(this.gameObject);

	}
}
