using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RingTossPresenter : MonoBehaviour
{
	[SerializeField] TMP_Text TMP_ScoreText;

	private RingTossBoothService _ringTossBoothService;

	private void start ()
	{
		_ringTossBoothService = FindObjectOfType<RingTossBoothService>();
		if(_ringTossBoothService != null)
		{
			_ringTossBoothService.ScoreUpdated += OnScoreUpdated;
		}
	}

	private void OnScoreUpdated(int newScore)
	{
		TMP_ScoreText.text = "Score: " + newScore;
	}

}
