using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ak74m_Bullet : Photon.MonoBehaviour {

	public GameObject bullet1;   //弾丸オブジェクトのプレファブ
	//public Transform muzzle;    //銃口の位置を取得する用
	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	//	public GameObject center;
	public float bulletSpeed;
	public float minLimit = 50;
	public AudioSource gunSound_1;
	public AudioSource gunSound_3;
	public GameObject EX;
	bool triggerOn;
	public LineRenderer ll;
	public GameObject Bulletcursor;

	//このオブジェクト(Bullet)が生成された瞬間に実行される。
	void Start(){
		triggerOn = false;
	}



	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			Bulletcursor.transform.position = point2.transform.position;
			Bulletcursor.transform.LookAt(this.gameObject.transform);
			//		Vector3 nowSpeed = rigidbody.velocity;

			//現在の速度が指定値以下になったら
			//		if (nowSpeed.sqrMagnitude <= minLimit) {
			//			Destroy (gameObject);
			//		}
			if (Input.GetKeyDown (KeyCode.G)) {
				point2.transform.position = point1.transform.position;
				triggerOn = true;
				gunSound_1.Play ();
			} else if (Input.GetKeyUp (KeyCode.G)) {
				triggerOn = false;
			}

			if (Input.GetKeyDown (KeyCode.F) && triggerOn) {
				PhotonNetwork.Instantiate ("Explosion", point1.transform.position, Quaternion.identity, 0);
				gunSound_3.Play ();
//				Debug.Log (transform.forward);s
//				Debug.Log (Quaternion.identity);
				GameObject b = PhotonNetwork.Instantiate ("0.45  Bullet", point1.transform.position, point1.transform.rotation, 0) as GameObject;//GameObject型に変換する。
//			center.transform.position = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
				//銃口の前方にbulletSpeed分の力を加える。
				b.GetComponent<Rigidbody> ().AddForce (point1.transform.forward * bulletSpeed);
			}
			if (triggerOn) {
				Bulletcursor.gameObject.SetActive (true);
				ll.enabled = true;
				photonView.RPC ("Draw", PhotonTargets.All);
			} else if (!triggerOn) {
				point2.transform.position = point1.transform.position;
				Bulletcursor.gameObject.SetActive (false);
				ll.enabled = false;
			}
		}
	}

	[PunRPC]
	void Draw (){
			int distance = 100000;
		point2.GetComponent<Rigidbody> ().AddForce (point1.transform.forward * bulletSpeed/100);
		//三角関数で二点間の角度を求める
			float dx = point1.transform.position.x - point2.transform.position.x;
			float dy = point1.transform.position.y - point2.transform.position.y;
			float rad = Mathf.Atan2 (dy, dx);

		//rayを飛ばす
			Ray ray = new Ray (point1.transform.position, point1.transform.forward * bulletSpeed);
			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, distance)) {
			Debug.DrawRay (ray.origin, hitInfo.point, Color.white);
			}

		//二点を取得してラインを引く
		Vector3[] positions = new Vector3[2];
		positions [0] = point1.transform.position;
		positions [1] = point2.transform.position;
		ll.SetPositions (positions);
	}

}