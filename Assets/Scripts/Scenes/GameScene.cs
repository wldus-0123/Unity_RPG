using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
	[SerializeField] Transform player;
	[SerializeField] CharacterController playerController;
	public override IEnumerator LoadingRoutine()
	{
		yield return null;
	}

	public void ToTitleScene()
	{
		Manager.Scene.LoadScene("TitleScene");
	}

	public override void SceneSave()
	{
		Manager.Data.gameData.sceneSaved[Manager.Scene.GetCurSceneIndex()] = true;	
		Manager.Data.gameData.gameSceneData.playerPos = player.position;
		Manager.Data.SaveData();
	}

	public override void SceneLoad()
	{
		if ( Manager.Data.gameData.sceneSaved [Manager.Scene.GetCurSceneIndex()] == false )
			return;


		Manager.Data.LoadData();
		playerController.enabled = false;
		player.position = Manager.Data.gameData.gameSceneData.playerPos;
		playerController.enabled = true;
	}
}
