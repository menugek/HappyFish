using UnityEngine;
using System.Collections;

public class SpawnDragon : MonoBehaviour {

	public Object Dragon;
	static public float SpawnSpeed = 5f;

	private float nextFire = 0f;

	void Start ()
	{
		SpawnSpeed = 5f;
	}

	void Update()
	{
		float Spawnposition = Random.Range (-2, 5);

		if (Time.time > nextFire)
			CloneDragon (Spawnposition);
	}

	void CloneDragon(float SpawnPos)
	{
		//Create the clone of the dragon Prefab
		nextFire = Time.time + SpawnSpeed;
		Instantiate (Dragon, new Vector3 (transform.position.x, SpawnPos, 0), transform.rotation);
	}
}