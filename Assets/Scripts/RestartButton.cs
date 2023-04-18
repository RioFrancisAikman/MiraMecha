using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button resetButton;

    void OnEnable()
    {
        //Register Button Event
        resetButton.onClick.AddListener(() => buttonCallBack());
    }

    private void buttonCallBack()
    {
        UnityEngine.Debug.Log("Clicked: " + resetButton.name);

        //Get current scene name
        string SampleScene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(SampleScene, LoadSceneMode.Single);

        Time.timeScale = 1;
    }

    void OnDisable()
    {
        //Un-Register Button Event
        resetButton.onClick.RemoveAllListeners();
    }
}
