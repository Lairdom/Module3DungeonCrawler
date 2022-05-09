using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    [SerializeField] Sprite openChest;
    [SerializeField] KeysUI _keysUI;
    MessageUI _lockedUI;
    [SerializeField] AudioClip chestUnlock;
    public string type;
    [SerializeField] GameObject silverKey, goldKey, coin, potion, bigPotion, shieldPotion, heart, item;
    public bool opened = false, locked = false;
    GameObject player;
    int keys;

    void checkContents() {
        if (type == "SilverKeyChest") {
            Instantiate(silverKey, new Vector2(transform.position.x,transform.position.y-2),transform.rotation);
        }
        if (type == "GoldKeyChest") {
            Instantiate(goldKey, new Vector2(transform.position.x,transform.position.y-2),transform.rotation);
        }
        if (type == "TreasureChest") {
            Instantiate(coin, new Vector2(transform.position.x,transform.position.y-2),transform.rotation);
            Instantiate(coin, new Vector2(transform.position.x+2,transform.position.y-1.5f),transform.rotation);
            Instantiate(coin, new Vector2(transform.position.x-2,transform.position.y-1.5f),transform.rotation);
            Instantiate(coin, new Vector2(transform.position.x+1.5f,transform.position.y+1),transform.rotation);
            Instantiate(coin, new Vector2(transform.position.x-1.5f,transform.position.y+1),transform.rotation);
        }
        if (type == "PotionChest") {
            Instantiate(bigPotion, new Vector2(transform.position.x,transform.position.y-2),transform.rotation);
        }
        if (type == "ItemChest") {
            item.GetComponent<SpriteRenderer>().enabled = true;
            item.GetComponent<Collider2D>().enabled = true;
        }
        if (type == "HeartChest") {
            Instantiate(heart, new Vector2(transform.position.x, transform.position.y+0.3f),transform.rotation);
        }
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Activate>().enabled = false;
        this.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _keysUI = GameObject.Find("Keys").GetComponent<KeysUI>();
        _lockedUI = GameObject.Find("Message").GetComponent<MessageUI>();
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
                    player.GetComponent<AudioSource>().PlayOneShot(chestUnlock);
                    keys -= 1;
                    _keysUI.showKeys(keys);
                    opened = true;
                    locked = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = openChest;
                    player.GetComponent<PlayerStats>().keys = keys;
                    checkContents();
                }
                else {
                    _lockedUI.setMessage("Locked");
                    StartCoroutine(_lockedUI.showMessage());
                } 
            }
            else if (gameObject.GetComponent<Activate>().activate == true && locked == false) {
                opened = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = openChest;
                checkContents();
            }
            gameObject.GetComponent<Activate>().activate = false;
        }   
    }
}
