using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    GameObject loadingText;

    public void GoToLevel() {
        SceneManager.LoadScene("Dungeon1");
        loadingText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void Quitgame() {
        Application.Quit();
    }

    void Start() 
    {
        loadingText = GameObject.Find("Loading");
    }

    void Update () {
        if (Input.GetButtonDown("Controller-Examine")) {
            GoToLevel();
        }
        else if (Input.GetButtonDown("Controller-UseItem")) {
            Quitgame();
        }
    }
}
