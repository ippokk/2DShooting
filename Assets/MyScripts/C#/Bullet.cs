﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject explosion;
	public float time;

	void Start () {

	}
	
	void Update () {
	
	}

//	void OnTriggerEnter(Collider c){
//		Destroy (this.gameObject);
//		Destroy (Instantiate (explosion, transform.position, transform.rotation), time);
//	}

	public void BulletCollision(){
		Destroy (this.gameObject);
		Destroy (Instantiate (explosion, transform.position, transform.rotation), time);
	}
}