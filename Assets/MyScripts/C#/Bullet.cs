using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;

	void Start () {

	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		Destroy (this.gameObject);
		GameObject e = Instantiate (explosion, transform.position, transform.rotation) as GameObject;
		Destroy (e, 1.0f);
	}
}