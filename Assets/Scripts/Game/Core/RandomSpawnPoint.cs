﻿using UnityEngine;

namespace Game.Core
{
	public class RandomSpawnPoint : MonoBehaviour
	{
		public Vector3 GetRandomSpawnPoint(Transform minPoint, Transform maxPoint)
		{
			Vector3 spawnPoint = Vector3.zero;
			bool verticalSpawn = Random.Range(0f,1f) > 0.5f;
			if (verticalSpawn)
			{
				spawnPoint.y = Random.Range(minPoint.position.y,maxPoint.position.y);
				spawnPoint.x = Random.Range(0f, 1f) > 0.5f ? minPoint.position.x : maxPoint.position.x;
			}
			else
			{
				spawnPoint.x = Random.Range(minPoint.position.x,maxPoint.position.x);
				spawnPoint.y = Random.Range(0f, 1f) > 0.5f ? minPoint.position.y : maxPoint.position.y;
			}
			return spawnPoint;
		}
	}
}