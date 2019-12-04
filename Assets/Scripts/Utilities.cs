using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Utilities : MonoBehaviour
{
    public TMP_Text MSpeed;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            loadingLoadLevel();
        }
    }

    public void Play()
    {
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void setMouseSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Mouse Speed", sensitivity);
        MSpeed.text = "Mouse Sensitivity: " + sensitivity;
    }

    public void loadingLoadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
}
