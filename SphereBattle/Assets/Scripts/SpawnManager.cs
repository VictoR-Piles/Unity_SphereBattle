using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float spawnRange = 9f;

	private int enemyCount;
	private int waveNum = 1;
	
	void Start()
	{
		SpawnEnemyWave(waveNum);
	}

	void Update()
	{
		enemyCount = FindObjectsOfType<EnemyController>().Length;

		if (enemyCount == 0)
		{
			waveNum++;
			SpawnEnemyWave(waveNum);
		}
	}

	void SpawnEnemyWave(int enemiesToSpawn)
	{
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			Instantiate(enemyPrefab, GetRandomSpawnPos(), enemyPrefab.transform.rotation);
		}
	}

	private Vector3 GetRandomSpawnPos()
	{
		float spawnPosX = Random.Range(-spawnRange, spawnRange);
		float spawnPosZ = Random.Range(-spawnRange, spawnRange);
		Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

		return randomPos;
	}
}