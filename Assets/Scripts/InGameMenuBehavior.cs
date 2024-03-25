
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuBehavior : BaseMenuBehavior
{
	public void OnPauseGameClicked()
	{
	// do pause game
	GameManager.Instance.UpdateGameState(GameState.Pause);
	}

}
