using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
	public abstract IEnumerator LoadingRoutine();

	public virtual void SceneSave()
	{

	}

	public virtual void SceneLoad()
	{

	}

	//[ContextMenu("Save")]
	//public void SaveScene()
	//{
	//	MonoBehaviour [] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
	//	foreach ( MonoBehaviour monoBehaviour in monoBehaviours )
	//	{
	//		ISaveLoadable saveLoadable = monoBehaviour as ISaveLoadable;
	//		saveLoadable?.SaveData(Manager.Data.GameData);
	//	}

	//	int index = Manager.Scene.GetCurSceneIndex();
	//	Manager.Data.GameData.sceneSaved [index] = true;
	//}

	//[ContextMenu("Load")]
	//public void LoadScene()
	//{
	//	int index = Manager.Scene.GetCurSceneIndex();
	//	if ( Manager.Data.GameData.sceneSaved [index] == false )
	//		return;

	//	MonoBehaviour [] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
	//	foreach ( MonoBehaviour monoBehaviour in monoBehaviours )
	//	{
	//		ISaveLoadable saveLoadable = monoBehaviour as ISaveLoadable;
	//		saveLoadable?.LoadData(Manager.Data.GameData);
	//	}
	//}
}
