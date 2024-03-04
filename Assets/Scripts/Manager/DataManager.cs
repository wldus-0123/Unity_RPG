using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
#if UNITY_EDITOR  //# 전처리기
	private string path => $"{Application.dataPath}/Data";

#else
    private string path => $"{Application.persistentDataPath}/Data";
#endif

	public GameData gameData;

	public void NewData()
	{
		gameData = new GameData();
		SaveData();
	}

	[ContextMenu("SaveData")]
	public void SaveData()
	{

		if ( Directory.Exists(path) == false )
		{
			Directory.CreateDirectory(path);
		}
		string filePath = Path.Combine(path, "Test.txt");
		string json = JsonUtility.ToJson(gameData, true);
		File.WriteAllText(filePath, json);
	}

	[ContextMenu("LoadData")]
	public void LoadData()
	{

		string filepath = Path.Combine(path, "Test.txt");

		if ( File.Exists(filepath) )
		{
			string json = File.ReadAllText(filepath);
			gameData = JsonUtility.FromJson<GameData>(json);
		}
		else
		{
			gameData = new GameData();
		}
	}

	public bool ExistSaveData()
	{
		string filepath = Path.Combine(path, "Test.txt");
		return File.Exists(filepath);
	}
}

