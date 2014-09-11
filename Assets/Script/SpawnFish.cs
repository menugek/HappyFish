using UnityEngine;
using System.Collections;

public class SpawnFish : MonoBehaviour {

	public Object Fish;
	public float SpawnSpeed = 5f;
	
	private float nextFire = 0f;

	void Start()
	{
		SpawnSpeed = 5f;
	}

	void Update()
	{
		float Spawnposition = Random.Range (-2, 5);
		
		if (Time.time > nextFire)
			CloneFish (Spawnposition);
	}
	
	void CloneFish(float SpawnPos)
	{
		//Create the clone of the dragon Prefab
		nextFire = Time.time + SpawnSpeed;
		Instantiate (Fish, new Vector3 (transform.position.x, SpawnPos, 0), transform.rotation);
	}
}
