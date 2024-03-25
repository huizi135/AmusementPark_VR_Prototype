
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : BaseMenuBehavior
{
	public override void ToggleMenu()
	{
		GameManager.Instance.UpdateGameState(GameState.Play);
		base.ToggleMenu();
	}


}
