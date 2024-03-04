using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : BaseScene
{
	[SerializeField] Button continueButton;
	private void Start()
	{
		bool exist = Manager.Data.ExistSaveData();
		continueButton.interactable = exist;
	}
	public void NewGame()
    {
        Manager.Data.NewData();
        Manager.Scene.LoadScene("GameScene");
    }

    public void ContinueGame()
    {
        Manager.Data.LoadData();
        Manager.Scene.LoadScene("GameScene");
    }

	public override IEnumerator LoadingRoutine()
	{
		yield return null;
	}
}
