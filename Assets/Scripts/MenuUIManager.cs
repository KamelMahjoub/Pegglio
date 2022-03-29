using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_Editor
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{

    public TMP_InputField nameField;
    public TextMeshProUGUI highScore;
    private string playerName;

    private void Awake()
    {
        DataManager.Instance.LoadData();
        nameField.text = DataManager.Instance.userName;
        highScore.text = "High Score : " + DataManager.Instance.userName + " : " + DataManager.Instance.highScore;
    }

    public void StartGame()
    {
        SetName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    public string GetName()
    {
        return playerName;
    }

    public void SetName()
    {
        playerName = nameField.text;
        DataManager.Instance.SetUserName(playerName);
    }
}
