
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public void CountryFlagClicked()
	{
		string clickedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		int selectCharachterIndex = int.Parse(clickedButtonName);
		GameManager.instance.CountryIndex = selectCharachterIndex;
		UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
		Debug.Log(GameManager.instance.CountryIndex);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
