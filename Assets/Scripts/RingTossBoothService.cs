
using UnityEngine;
using System;

public class RingTossBoothService : MonoBehaviour
{
	public event Action<int> ScoreUpdated;


	[SerializeField] private GameObject[] rings;
	[SerializeField] private int scoreToAdd = 10;

	private int _score;

	private Vector3[] _ringStartingPositions;
	private Quaternion[] _ringStartingRotations;

	private void Start()
	{
		_ringStartingPositions = new Vector3[rings.Length];
		_ringStartingRotations = new Quaternion[rings.Length];

		for (int i = 0; i < rings.Length; i++)
		{
			_ringStartingPositions[i] = rings[i].transform.position;
			_ringStartingRotations[i] = rings[i].transform.rotation;
		}
	}

	public void AddToScore()
	{
		_score += scoreToAdd;
		ScoreUpdated?.Invoke(_score);
	}

	[ContextMenu("Reset Game")]

	public void ResetGame()
	{
		for (int i = 0; i < rings.Length; i++)
		{
			rings[i].transform.SetPositionAndRotation(_ringStartingPositions[i], _ringStartingRotations[i]);
		}
		_score = 0;
		ScoreUpdated?.Invoke(_score);
	}

}
