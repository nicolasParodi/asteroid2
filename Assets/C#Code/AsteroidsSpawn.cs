using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour {

	public float spawnCD = 1.0f;
	public float spawnCDremaining = 0;

	[System.Serializable]
	public class WaveComponent {
		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}

	public WaveComponent[] waveComps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnCDremaining -= Time.deltaTime;
		if (spawnCDremaining < 0) 
		{
			spawnCDremaining = spawnCD;
			bool didSpawn = false;
			foreach (WaveComponent wc in waveComps) 
			{
				Vector3 pos = new Vector3 (Random.Range (-7.0f, 7.0f), 7.0f, -0.286828f);
				Instantiate (wc.enemyPrefab, pos, this.transform.rotation);
				didSpawn = true;
			}
		}
	}
}
