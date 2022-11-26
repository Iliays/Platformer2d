using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
	[SerializeField] private float _secondsBetweenSpawn;

	private float _elapsedTime = 0;

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		if (_elapsedTime >= _secondsBetweenSpawn)
		{
			_elapsedTime = 0;

			int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
			Instantiate(_coinPrefab, _spawnPoints[spawnPointNumber]);
		}
	}
}