using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public string keyType;
    GameObject player;
    KeysUI _keysUI;
    MessageUI _messageUI;
    [SerializeField] AudioClip keyPickup;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (keyType == "SilverKey") {
                player.GetComponent<PlayerStats>().keys += 1;
                _keysUI.showKeys(player.GetComponent<PlayerStats>().keys);
                _messageUI.setMessage("Key Obtained");
                StartCoroutine(_messageUI.showMessage());
                player.GetComponent<AudioSource>().pitch = 1;
                player.GetComponent<AudioSource>().PlayOneShot(keyPickup);
                Destroy(gameObject);
            }
            else if (keyType == "GoldKey") {
                // player.GetComponent<PlayerStats>().keys += 1;
                _messageUI.setMessage("Golden Key Obtained");
                StartCoroutine(_messageUI.showMessage());
                player.GetComponent<AudioSource>().pitch = 0.5f;
                player.GetComponent<AudioSource>().PlayOneShot(keyPickup);
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _keysUI = GameObject.Find("Keys").gameObject.GetComponent<KeysUI>();
        _messageUI = GameObject.Find("Message").GetComponent<MessageUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
