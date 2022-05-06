using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    GameObject loadingText;
    // Start is called before the first frame update
    public void GoToLevel() {
        SceneManager.LoadScene("Dungeon1");
        loadingText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    void Start() 
    {
        loadingText = GameObject.Find("Loading");
    }

    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            GoToLevel();
        }
    }
}
