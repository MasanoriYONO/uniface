using UnityEngine;
using System.Collections;

public class uniface : MonoBehaviour {

	private bool connected = false;
	private bool fb_published = false;
	private string fb_publish_message = "";
	public GUISkin skin;

	void OnGUI ()
	{
		GUI.skin = skin;
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 200, Screen.height / 2, 400, 300));
		if (fb_published) {
			GUILayout.Label ("投稿しました。");
		}
/*
		if (!connected) {
			if (GUILayout.Button ("FBと連携")) {
				Application.ExternalCall ("connect");
				connected = true;
			}
		} else {
*/			GUILayout.BeginHorizontal (GUILayout.Width (200));
			fb_publish_message = GUILayout.TextField (fb_publish_message, GUILayout.Width (150));
			if (GUILayout.Button ("自分のウォールへ投稿")) {
				Application.ExternalCall ("publishStream",
						fb_publish_message + "[UnityからFBへ投稿]",
						gameObject.name,
						"Call");
				fb_publish_message = "";
			}
			GUILayout.EndHorizontal ();
			GUILayout.Label ("動作しなかった場合は再度FBとの接続を試してください。");
			if (GUILayout.Button ("FBと連携")){
				Application.ExternalCall ("connect");
			}
//		}
		GUILayout.EndArea ();
	}
	void Call ()
	{
		fb_published = true;
	}
	
	//HTML側から認証したかどうかを設定する。
	void IsAuthorized(bool flg) {
		connected = flg;
		Application.ExternalCall( "echoback", flg);
	}
}