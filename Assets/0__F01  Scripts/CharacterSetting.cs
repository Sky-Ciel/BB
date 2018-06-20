using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CharacterSetting : MonoBehaviour {

	public Dropdown setting_1;
	public GameObject PlayerEditor;
	public Material[] Colors = new Material[3];
	public static int colorSet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerEditor.GetComponent<Renderer>().material = Colors[setting_1.value];
	}

	public void SettingSuccess (){
//		if (photonView.isMine) {
			colorSet = setting_1.value;
			SceneManager.LoadScene ("Field_1");
//		}
	}


}