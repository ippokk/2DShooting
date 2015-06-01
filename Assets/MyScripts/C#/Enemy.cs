using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	float speed;
	float width;
	float height;
	public int life = 10;
	int dx;
	int dy;
	int sf;
	
	void Start () {
		speed = 200;
		width  = transform.FindChild ("body").gameObject.GetComponent<Renderer> ().bounds.size.x;
		height = transform.FindChild ("body").gameObject.GetComponent<Renderer> ().bounds.size.y;
	}
	
	void Update () {
		Move ();
	}

	void Move () {
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));
		Vector2 pos = transform.position;
		if (Time.frameCount % 6 == 0) {
			dx = Random.Range (0, 3) - 1;
			dy = Random.Range (0, 3) - 1;
			if (pos.x < -300)
				dx = 1;
			if (pos.x > 100)
				dx = -1;
			if (pos.y < 0)
				dy = 1;
			if (pos.y > 200)
				dy = -1;
		}
		Vector2 direction = new Vector2 (dx, dy).normalized;
		pos += direction * speed * Time.deltaTime;
		pos.x = Mathf.Clamp (pos.x, min.x + width/2, max.x- width/2);
		pos.y = Mathf.Clamp (pos.y, min.y + height, max.y - height);
		transform.position = pos;
	}

	void OnTriggerEnter (Collider c) {
		life -= 1;
		if (life < 1) {
			Explore();		
		}
	}

	void Explore () {
		Destroy (this.gameObject);
	}
}