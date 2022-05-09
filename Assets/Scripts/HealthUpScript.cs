using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpScript : MonoBehaviour
{
    GameObject player;
    MessageUI _messageUI;
    [SerializeField] AudioClip pickUp;

    void Start()
    {
        player = GameObject.Find("Player");
        _messageUI = GameObject.Find("Message").GetComponent<MessageUI>();
    }

    void Update()
    {
        if (player != null) {
            if (gameObject.GetComponent<Activate>().activate == true) {
                player.GetComponent<AudioSource>().volume = 0.1f;
                player.GetComponent<AudioSource>().PlayOneShot(pickUp);
                player.GetComponent<AudioSource>().volume = 0.2f;
                player.GetComponent<PlayerStats>().maxHealth += 20;
                player.GetComponent<PlayerStats>().currentHealth += 20;
                _messageUI.setMessage("Max Health Increased");
                StartCoroutine(_messageUI.showMessage());
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject,2.5f);
            }
            gameObject.GetComponent<Activate>().activate = false;
        }
    }
}
