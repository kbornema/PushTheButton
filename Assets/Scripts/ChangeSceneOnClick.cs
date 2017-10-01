using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour 
{
    public string _sceneName;

	// Use this for initialization
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
