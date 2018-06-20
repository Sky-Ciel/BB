using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerContoroller : Photon.MonoBehaviour {

	public float MY_HP;
	public float speed;
	private float speedMAX;
	private static float AGI = 10.0f;
	public float rotateSpeed = 10.0F;
	private CharacterController controller;

	public float spinSpeed = 0.5f;
	float distance = 10f;
	Vector3 pos = Vector3.zero;
	public Vector2 mouse = Vector2.zero;
	public GameObject cam;
	public GameObject cam_origin;
	public Material[] Colors = new Material[3];
	public GameObject _thisBody;

	void Start () {
		if (photonView.isMine) {
			Debug.Log ("ログイン成功");
			Debug.Log ("ゲームを開始します");
			mouse.x = -0.5f;
			mouse.y = 0.5f;
			this.MY_HP = 100;
			speed = AGI;
			controller = GetComponent<CharacterController> ();
			_thisBody.GetComponent<Renderer>().material = Colors[CharacterSetting.colorSet];
		}
	}
	

	void Update() {
		if (photonView.isMine) {
			cam_origin.SetActive (true);

			speedMAX = AGI * 2;

			float curxSpeed = speed * Input.GetAxis ("Horizontal");
			controller.SimpleMove (transform.right * curxSpeed);
			float curzSpeed = speed * Input.GetAxis ("Vertical");
			controller.SimpleMove (transform.forward * curzSpeed);
			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = speedMAX;
			} else {
				speed = AGI;
			}

			Cursor.lockState = CursorLockMode.Locked;
			mouse += new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y")) * Time.deltaTime * spinSpeed;
			mouse.y = Mathf.Clamp(mouse.y, -0.3f + 0.5f, 0.3f + 0.5f);
			// 球面座標系変換
			pos.x = distance * Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Cos(mouse.x * Mathf.PI);
			pos.y = -distance * Mathf.Cos(mouse.y * Mathf.PI);
			pos.z = -distance * Mathf.Sin(mouse.y * Mathf.PI) * Mathf.Sin(mouse.x * Mathf.PI);
			// 座標の更新
			cam.transform.LookAt(pos + cam.transform.position);
		}
		if (!photonView.isMine) {
			cam_origin.SetActive (false);
		}
	}

	public void Damage (){
		if (photonView.isMine) {
			this.MY_HP -= 10;
			Debug.Log ("警告:HPが減少しました。");
		}
	}

}
