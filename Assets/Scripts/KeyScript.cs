using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public string keyType;
    GameObject player;
    KeysUI _keysUI;
    [SerializeField] AudioClip keyPickup;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (keyType == "SilverKey") {
                player.GetComponent<PlayerStats>().keys += 1;
                _keysUI.showKeys(player.GetComponent<PlayerStats>().keys);
                player.GetComponent<AudioSource>().pitch = 1;
                player.GetComponent<AudioSource>().PlayOneShot(keyPickup);
                Destroy(gameObject);
            }
            else if (keyType == "GoldKey") {
                // player.GetComponent<PlayerStats>().keys += 1;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
