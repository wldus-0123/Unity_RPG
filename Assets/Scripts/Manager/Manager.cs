using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    public static Manager Inst { get { return instance; } }

    [SerializeField] SceneManager sceneManager;
    [SerializeField] DataManager dataManager;

    public static SceneManager Scene {get{return instance.sceneManager;}}
    public static DataManager Data { get { return instance.dataManager;}}

	private void Awake()
	{
		if(instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
