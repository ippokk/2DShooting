using UnityEngine;
using System.Collections;

public class EnemyInfo {

	// basis
	public int frame{ get; set;}
	public int enemy{ get; set;}
	public int life{ get; set;}

	// move
	public int move_ptn{ get; set;}
	public float x{ get; set;}
	public float y{ get; set;}
	public float move_spd{ get; set;}

	// shot
	public int bullet{ get; set;}
	public int shot_ptn{ get; set;}
	public int interval{ get; set;}
	public float shot_spd{ get; set;}

	public void Initialize (string line) {
		char[] div = {'\t', ','};
		string[] par = line.Split(div);
		this.frame    = int.Parse(par[0]);
		this.enemy    =	int.Parse(par[1]);
		this.life     =	int.Parse(par[2]);
		this.move_ptn = int.Parse(par[3]);
		this.x        =	float.Parse(par[4]);
		this.y        =	float.Parse(par[5]);
		this.move_spd = float.Parse(par[6]);
		this.bullet   =	int.Parse(par[7]);
		this.shot_ptn = int.Parse(par[8]);
		this.interval = int.Parse(par[9]);
		this.shot_spd = float.Parse(par[10]);
	}
}
