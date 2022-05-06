using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairsTeleport : MonoBehaviour
{
    string teleTo;
    GameObject UI;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Stairs1to2") {
            teleTo = "Stairs2";
            StartCoroutine(FadeInto());
        }
            
        if (col.name == "Stairs2to1") {
            teleTo = "Stairs1";
            StartCoroutine(FadeInto());
        }
            
        if (col.name == "Stairs3to4") {
            teleTo = "Stairs4";
            StartCoroutine(FadeInto());
        }
            
        if (col.name == "Stairs4to3") {
            teleTo = "Stairs3";
            StartCoroutine(FadeInto());
        }
            
        if (col.name == "Stairs5to6") {
            teleTo = "Stairs6";
            StartCoroutine(FadeInto());
        }
            
        if (col.name == "Stairs6to5") {
            teleTo = "Stairs5";
            StartCoroutine(FadeInto());
        }
        if (col.name == "Stairs7to8") {
            teleTo = "Stairs8";
            StartCoroutine(FadeInto());
        }
        if (col.name == "Stairs8to7") {
            teleTo = "Stairs7";
            StartCoroutine(FadeInto());
        }
        if (col.name == "Stairs9toBoss") {
            teleTo = "StairsBoss";
            StartCoroutine(FadeInto());
        }
        if (col.name == "StairsBossTo9") {
            teleTo = "Stairs9";
            StartCoroutine(FadeInto());
        }
            
        
    }

    IEnumerator FadeInto() {
        // Play Stairs Sound
        
        // Fade out
        UI.GetComponent<FadeToBlack>().FadeOut();
        yield return new WaitForSeconds(1);

        // Fade in
        UI.GetComponent<FadeToBlack>().FadeIn();

        if (teleTo == "Stairs1")
            transform.position = new Vector2(-99f,42.2f);
        if (teleTo == "Stairs2")
            transform.position = new Vector2(-15f,13.5f);
        if (teleTo == "Stairs3")
            transform.position = new Vector2(23f,6f);
        if (teleTo == "Stairs4")
            transform.position = new Vector2(40f,-28f);
        if (teleTo == "Stairs5")
            transform.position = new Vector2(-22.3f,-19.7f);
        if (teleTo == "Stairs6")
            transform.position = new Vector2(-53f,-38.2f);
        if (teleTo == "Stairs7")
            transform.position = new Vector2(-5f,-9.5f);
        if (teleTo == "Stairs8")
            transform.position = new Vector2(-5f,-30f);
        if (teleTo == "Stairs9")
            transform.position = new Vector2(-2.95f,26f);
        if (teleTo == "StairsBoss")
            transform.position = new Vector2(3f,50f);
        yield return new WaitForSeconds(1);
    }
    void Start()
    {
        UI = GameObject.Find("UI");
    }

    void Update()
    {

    }
}
