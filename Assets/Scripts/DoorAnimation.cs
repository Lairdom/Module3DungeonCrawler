using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] Sprite openDoor, closedDoor;
    [SerializeField] KeysUI _keysUI;
    MessageUI _lockedUI;
    [SerializeField] AudioClip doorUnlock;
    public bool opened, locked;
    GameObject player;
    int keys;

    void UpdateState() {
        if (opened == false) {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = closedDoor;
        }
        else {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _lockedUI = GameObject.Find("Message").GetComponent<MessageUI>();
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            keys = player.GetComponent<PlayerStats>().keys;
            if (gameObject.GetComponent<Activate>().activate == true && locked == true) {
                if (keys > 0) {
                    _lockedUI.setMessage("Key Used");
                    StartCoroutine(_lockedUI.showMessage());
                    player.GetComponent<AudioSource>().pitch = 1;
                    player.GetComponent<AudioSource>().PlayOneShot(doorUnlock);
                    keys -= 1;
                    _keysUI.showKeys(keys);
                    opened = true;
                    locked = false;
                    UpdateState();
                    player.GetComponent<PlayerStats>().keys = keys;
                }
                else {
                    _lockedUI.setMessage("Locked");
                    StartCoroutine(_lockedUI.showMessage());
                } 
            }
            else if (gameObject.GetComponent<Activate>().activate == true && locked == false) {
                opened = true;
                UpdateState();
            }
            gameObject.GetComponent<Activate>().activate = false;
        }
    }
}
