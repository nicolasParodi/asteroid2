using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawn : MonoBehaviour
{

	public float spawnCD = 1.0f;
	public float spawnCDremaining = 0;

	[System.Serializable]
	public class WaveComponent
    {
		public GameObject enemyPrefab;
		public int CantidadEnemigos;
	    [System.NonSerialized]
	    public int spawned = 0;
        public float Velocidad = 0.25f;
	}

	public WaveComponent[] waveComps;

	public void Init()
	{
		gameObject.SetActive (true);
	}

	public void Stop()
	{
		gameObject.SetActive (false);
	}
	
	void Update () 
	{
		spawnCDremaining -= Time.deltaTime;
		if (spawnCDremaining <=0) 
		{
			spawnCDremaining = spawnCD;
			bool didSpawn = false;
			foreach (WaveComponent wc in waveComps) 
			{
				Vector3 pos = new Vector3 (Random.Range (-6.11f, 6.36f), 6.76f, -0.286828f);
				Instantiate (wc.enemyPrefab, pos, this.transform.rotation);
				didSpawn = true;
			}
		}
	}
}
