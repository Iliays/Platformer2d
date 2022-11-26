using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	private int _coins;

	public event UnityAction<int> CoinChanged;

	public void IncreaseScore()
	{
		_coins++;
		CoinChanged?.Invoke(_coins);
	}
}