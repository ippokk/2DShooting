using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		Destroy (this.gameObject);
	}
}