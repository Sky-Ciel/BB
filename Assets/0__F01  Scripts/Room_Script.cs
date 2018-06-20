using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Script : MonoBehaviour {


	void Start() {
		// ポイント2: サーバーに接続する。引数は0.1でよい
		// サーバー接続に成功した後は自動でLobbyに参加する
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	// Lobbyに参加した時に呼ばれる
	void OnJoinedLobby() {
		//すでに存在しているRoomにランダムに入る
		PhotonNetwork.JoinRandomRoom();
	}

	// ランダムにRoomに参加するのに失敗した時に呼ばれる
	void OnPhotonRandomJoinFailed() {
		//Roomを自分で作って参加する
		PhotonNetwork.CreateRoom(null);
	}

	// Roomに参加するのに成功した時に呼ばれる
	void OnJoinedRoom() {
		PlayerMake();
	}

	// ポイント3: Playerを生成するメソッド
	void PlayerMake(){
		// Resourcesフォルダに入っている"Player"という名前のオブジェクトを生成する。
		// 第一引数がGameObject型ではなくString型であることに注意
		PhotonNetwork.Instantiate("FPSController", Vector3.zero, Quaternion.identity, 0);

	}

	// ゲームには不要だが、接続状態を確認できるので、製作途中では重宝する
	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

}
