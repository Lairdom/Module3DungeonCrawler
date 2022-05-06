using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerBoss : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip victoryTheme;
    [SerializeField] GameObject boss, chest;
    GameObject UI, newChest;
    
    bool triggered = false, end = false;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            triggered = true;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            boss.GetComponent<SkullBossAI>().enabled = true;
        }
    }

    IEnumerator End() {
        source.Stop();
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        source.PlayOneShot(victoryTheme);
        end = true;
        yield return new WaitForSeconds(2);
        UI.GetComponent<FadeToBlack>().FadeOut();
        UI.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        UI.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = "You Win";
    }

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("SkullBoss");
        source = GameObject.Find("UI").GetComponent<AudioSource>();
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true && end != true && boss == null) {
            StartCoroutine(End());
        }
        else if (end == true) {
            if (Input.anyKey) {
                UI.GetComponent<FadeToBlack>().QuitGame();
            }
        }
        
    }
}
