using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnRange = 9f;

	void Start()
	{
		Instantiate(enemyPrefab, GetRandomSpawnPos(), enemyPrefab.transform.rotation);
	}

	private Vector3 GetRandomSpawnPos()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

		return randomPos;
	}
}