using UnityEngine;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour {

	string log = "\n";

	void Start () {
	
	}

	void Update () {
	
	}

	public void InputLogging (int dx, int dy){
		log += (dx + 1).ToString ();
		log += (dy + 1).ToString ();
	}

	public void OutputLog (){
		string fname = Time.frameCount.ToString ();
		FileStream fstream = new FileStream("Log/" + fname +".txt", FileMode.Create, FileAccess.Write);
		BinaryWriter writer = new BinaryWriter(fstream);
		writer.Write(log);
		writer.Close();
		Debug.Log ("end");
	}
}
