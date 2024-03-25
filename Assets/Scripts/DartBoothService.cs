
using UnityEngine;

public class DartBoothService : MonoBehaviour
{
	[SerializeField] GameObject[] balloons;

	private int _balloonsPopped;
	public float Timer => _timer;
	private float _timer;


	public bool IsTimerRunning => _isTimerRunning;
	private bool _isTimerRunning;

	private void Update()
	{
		if(_isTimerRunning)
		{
			_timer += Time.deltaTime;
		}
	}

	public void StartGame()
	{
		_isTimerRunning = true;
	}

	public void PopBalloon()
	{
		_balloonsPopped++;
		if(_balloonsPopped == balloons.Length)
		{
			PauseGame();
		}
	}

	private void PauseGame()
	{
		_isTimerRunning = false;
	}

	[ContextMenu("Reset Game")]

	public void ResetGame()
	{
		_balloonsPopped = 0;
		_timer = 0;
		foreach(GameObject balloon in balloons)
		{
			balloon.gameObject.SetActive(true);
		}
	}

}
