using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	[SerializeField] private Coin _coinPrefab;
	[SerializeField] private Transform[] _spawnPoints;
	[SerializeField] private float _delay;

	private bool _isGameActive = true;

	private void Start()
	{
		StartCoroutine(Delay(_delay));
	}

	private IEnumerator Delay(float delay)
	{
		var waitForDelay = new WaitForSeconds(delay);

		while (_isGameActive)
		{
			int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
			Instantiate(_coinPrefab, _spawnPoints[spawnPointNumber]);

			yield return waitForDelay;
		}
	}
}