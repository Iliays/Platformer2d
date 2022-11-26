using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinView : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private TMP_Text _coinView;

	private void OnEnable()
	{
		_player.CoinChanged += OnScoreChanged;
	}

	private void OnDisable()
	{
		_player.CoinChanged -= OnScoreChanged;
	}

	private void OnScoreChanged(int coin)
	{
		_coinView.text = coin.ToString();
	}
}