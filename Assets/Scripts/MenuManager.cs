using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject panelSettings;
    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ActiveSettingsMenu()
    {
        bool isActive = panelSettings.activeSelf;
        panelSettings.SetActive(!isActive);
    }
}
