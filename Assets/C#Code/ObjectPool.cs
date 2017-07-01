using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour {
	
	private GameObject[] objectPool = null;

	public GameObject objectToInstantiated;

	public int poolSize = 10;


	void Start ()
	{
		objectPool = new GameObject[poolSize];
		for (int i = 0; i < poolSize; i++)
		{
			objectPool[i] = Instantiate(objectToInstantiated) as GameObject;
			objectPool[i].transform.parent = gameObject.transform;
			objectPool[i].SetActive(false);
		}
	}

	public void ActivateObjects(Vector3 position, Quaternion rotation)
	{
		for (int i = 0; i < poolSize; i++)
		{
			if (objectPool [i].activeInHierarchy == false)
			{
				objectPool [i].transform.position = position;
				objectPool [i].transform.rotation = rotation;
				objectPool [i].SetActive(true);
				return;
			}
		}
	}
}
