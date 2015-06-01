using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	float speed;
	float width;
	float height;
	//public Bullet bullet_01;
	float dx;
	float dy;

	void Start () {
		speed = 0.5f;
		width  = transform.FindChild ("body").gameObject.GetComponent<Renderer> ().bounds.size.x;
		height = transform.FindChild ("body").gameObject.GetComponent<Renderer> ().bounds.size.y;
	}
	
	void Update () {
		Move ();
//		if (Time.frameCount % 10 == 0 && sf == 1) {
//			Shot();
//		}
	}

	void Move () {
		dx = Input.GetAxisRaw("Horizontal");
		dy = Input.GetAxisRaw("Vertical");
//		if (Time.frameCount % 6 == 0) {
//			dx = Random.Range (0, 3) - 1;
//			dy = Random.Range (0, 3) - 1;
//			sf = Random.Range (0, 2);
//		}
		Vector2 direction = new Vector2 (dx, dy).normalized;
		direction = Vector2.Scale(direction,new Vector2(speed,speed));
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));
		Vector2 pos = transform.position;
		//pos += direction * speed * Time.deltaTime;
		transform.GetComponent<Rigidbody> ().AddForce (direction, ForceMode.Impulse);
		pos.x = Mathf.Clamp (pos.x, min.x + width/2, max.x- width/2);
		pos.y = Mathf.Clamp (pos.y, min.y + height, max.y - height);
		if (Input.GetKey(KeyCode.Alpha0)){
			transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		transform.position = pos;
	}

//	void Shot () {
//		Bullet bullet_clone = Instantiate (bullet_01, transform.position, transform.rotation) as Bullet;
//		bullet_clone.GetComponent<Rigidbody>().velocity = new Vector3 (0, 1000, 0);
//	}
}