using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Speed;
	public Camera mainCam;

	bool FacingRight = true;
	bool DeathB = false;
	
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
						rigidbody2D.velocity = new Vector2 (0, 0);
				}
		if (Input.GetMouseButtonUp (0)) {
						rigidbody2D.velocity = new Vector2 (0, 0);
			anim.SetBool ("RunBool", false);
		}
	}

	void FixedUpdate () 
	{
		if (DeathB) 
		{
			rigidbody2D.velocity = new Vector2 (0, -2);
			if (Input.GetMouseButtonDown (0))
				Application.LoadLevel("Menu");
			return;
		}
		if (Input.GetMouseButton (0))
		{
			//Hold Mouse Button
			anim.SetBool ("RunBool", true);
			Vector2 newpos = mainCam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			if (newpos.x > transform.position.x)
			{
				rigidbody2D.velocity = new Vector2 (Speed, rigidbody2D.velocity.y);
				if (!FacingRight)
					Flip ();
			}
			else if (newpos.x < transform.position.x)
			{
				rigidbody2D.velocity = new Vector2 (-Speed, rigidbody2D.velocity.y);
				if (FacingRight)
					Flip ();
			}
			if (newpos.y > transform.position.y)
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Speed);
			else if (newpos.y < transform.position.y)
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -Speed);
		}
	}

	void Flip()
	{
		FacingRight = !FacingRight;
		Vector3 LS = transform.localScale;
		LS.x *= -1;
		transform.localScale = LS;
	}



	void OnCollisionEnter2D(Collision2D col)
	{
		anim.SetTrigger ("DeathTrig");
		DeathB = true;
		rigidbody2D.isKinematic = true;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameManager.AddScore ();
	}


}
