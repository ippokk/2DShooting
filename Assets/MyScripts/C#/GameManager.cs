using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

//	string log = "\n";

	// stage
	public string stage;

	// player
	public Player player;

	// enemy
	public Enemy[] enemys;

	// bullet
	public Bullet[] bullets; 

	// constitution
	List<EnemyInfo> ei = new List<EnemyInfo>();

	void Start () {
		Application.targetFrameRate = 60;
		LoadGameConstitution (stage);
	}

	void Update () {
		while (ei.Count != 0 && Time.frameCount == ei [0].frame) {
			Emitter(ei [0]);
			ei.RemoveAt(0);
		}
//		Debug.Log (Camera.main.WorldToViewportPoint(new Vector2 (player.transform.position.x, player.transform.position.y)));
	}

	void Emitter(EnemyInfo _ei){
		Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2 (_ei.x, _ei.y));
		Enemy enemy_clone = Instantiate (enemys[_ei.enemy], new Vector3 (pos.x, pos.y, 0), transform.rotation) as Enemy;
		enemy_clone.Initialize (bullets[_ei.bullet], _ei.life, _ei.move_spd);
	}

	void LoadGameConstitution (string path) {
		TextAsset t = Resources.Load ("Text/" + path) as TextAsset;
		char[] div = {'\n'};
		string[] line = t.text.Split(div);
		for (int i = 0; i < line.Length; i++) {
			if(line [i].StartsWith("#")){
				continue;
			}
			EnemyInfo e = new EnemyInfo();
			e.Initialize(line [i]);
			ei.Add(e);
		}
	}

//	public void InputLogging (int dx, int dy){
//		log += (dx + 1).ToString ();
//		log += (dy + 1).ToString ();
//	}
//
//	public void OutputLog (){
//		string fname = Time.frameCount.ToString ();
//		FileStream fstream = new FileStream("Log/" + fname +".txt", FileMode.Create, FileAccess.Write);
//		BinaryWriter writer = new BinaryWriter(fstream);
//		writer.Write(log);
//		writer.Close();
//		Debug.Log ("end");
//	}
}
