using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    GameObject player;
    Image blackScreen;
    Color tempColor;
    bool startFade, fadeIn, dead;

    public void FadeOut() { 
        startFade = true;
    }
    public void FadeIn() { 
        fadeIn = true;
    }

    public void QuitGame() {
        SceneManager.LoadScene("Title");
    }
    void Start()
    {
        player = GameObject.Find("Player");
        blackScreen = GameObject.Find("BlackScreen").GetComponent<Image>();
        tempColor = blackScreen.color;
    }

    void Update()
    {
        if (player != null) {
            dead = player.GetComponent<PlayerStats>().dead;
        }
        if (dead == true) {
            if (Input.anyKey) {
                QuitGame();
            }
        }
        if (startFade == true && tempColor.a < 1) {
            tempColor.a += 5f * Time.deltaTime;
            blackScreen.color = tempColor;
        }
        else if (startFade == true && tempColor.a >= 1) {
            startFade = false;
        }
        if (fadeIn == true && tempColor.a > 0) {
            tempColor.a -= 5f * Time.deltaTime;
            blackScreen.color = tempColor;
        }
        else if (fadeIn == true && tempColor.a <= 0)
            fadeIn = false;
    }
}
