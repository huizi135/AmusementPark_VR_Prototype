
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseMenuBehavior : MonoBehaviour
{
	[SerializeField] private GameObject defaultMenuScreen;
	[SerializeField] private GameObject settingsScreen;
	[SerializeField] private Text snapTurnButtonText;

	private PlayerBehavior _playerBehavior;
	private bool _isMenuOpen;

	private void Start()
	{
		_playerBehavior = FindObjectOfType<PlayerBehavior>();
	}

	public virtual void ToggleMenu()
	{
		if (GameManager.Instance.State == GameState.Start) return;

		_isMenuOpen = !_isMenuOpen;
		defaultMenuScreen.SetActive(_isMenuOpen);
		settingsScreen.SetActive(false);
	}

	public void OnSettingsClicked()
	{
		defaultMenuScreen.SetActive(false);
		settingsScreen.SetActive(true);
	}

	public void OnQuitClicked()
	{
		GameManager.Instance.UpdateGameState(GameState.Quit);
	}

	public void OnToggleSnapTurnClicked()
	{
		bool isSnapTurnOn = _playerBehavior.ToggleSnapTurn();

		if(isSnapTurnOn)
		{
			snapTurnButtonText.text = "Toggle Snap Turn: On";
		}
		else
		{
			snapTurnButtonText.text = "Toggle Snap Turn: Off";		
		}
	}

	public void OnSettingsBackClicked()
	{
		defaultMenuScreen.SetActive(true);
		settingsScreen.SetActive(false);
	}
}
