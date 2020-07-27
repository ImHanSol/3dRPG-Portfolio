using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
	private List<GameObject> monsterPrefab = new List<GameObject>();
	private List<Vector3> positions = new List<Vector3>();

	private bool isSpawn = false;
	private float spawnDelay = 1.5f;
	private float spawnTimer = 0f;

	void Spawn()
	{
		if (positions.Count > monsterPrefab.Count)
			isSpawn = true;
		else isSpawn = false;
		
		if (isSpawn == true)
		{
			if (spawnTimer > spawnDelay)
			{
				for (int i = 0; i < positions.Count; i++)
				{
					for (int j = 0; j < monsterPrefab.Count; j++)
					{
						Instantiate(monsterPrefab[i], positions[j], Quaternion.identity);
					}
				}

				spawnTimer = 0f;
			}

			spawnTimer += Time.deltaTime;
		}
	}
}
