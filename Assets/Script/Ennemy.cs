using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {

	static public float Speed = 2f;
	public LayerMask colMask;

	void Start()
	{
		Speed = 2f;
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector2 (-Speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if ((colMask.value & (1 << other.gameObject.layer)) == 0)
			return;
		Destroy (gameObject);
	}
}
