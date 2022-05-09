using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] Image item;
    [SerializeField] Sprite fullPotion, halfPotion, emptyPotion, bomb;
    [SerializeField] TextMeshProUGUI _itemCountUI;
    GameObject player;
    int bombCount, coinCount;
    bool bombItem, potionItem;

    public void ChangeIcon(string icon)
    {
        if (icon == "Coin") {
            item.GetComponent<Image>().sprite = null;
            _itemCountUI.enabled = false;
            potionItem = false;
            bombItem = false;
        }
        else if (icon == "FullPotion") {
            item.GetComponent<Image>().sprite = fullPotion;
            _itemCountUI.enabled = false;
            potionItem = true;
            bombItem = false;
        }
        else if (icon == "HalfPotion") {
            item.GetComponent<Image>().sprite = halfPotion;
            _itemCountUI.enabled = false;
            potionItem = true;
            bombItem = false;
        }
        else if (icon == "EmptyPotion") {
            item.GetComponent<Image>().sprite = emptyPotion;
            _itemCountUI.enabled = false;
            potionItem = true;
            bombItem = false;
        }
        else if (icon == "Bomb") {
            item.GetComponent<Image>().sprite = bomb;
            _itemCountUI.enabled = true;
            potionItem = false;
            bombItem = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ChangeIcon(player.GetComponent<UseItem>().itemName);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            bombCount = player.GetComponent<UseItem>().bombCount;
            coinCount = player.GetComponent<UseItem>().coinCount;
            

            if (bombItem && bombCount <= 0) {
                item.GetComponent<Image>().color = new Color(1,1,1,0.3f);
                _itemCountUI.text = ""+bombCount;
            }
            else if (bombItem) {
                item.GetComponent<Image>().color = new Color(1,1,1,1f);
                _itemCountUI.text = ""+bombCount;
            }
            else if (potionItem && player.GetComponent<UseItem>().coolDown > 0)  
                item.GetComponent<Image>().color = new Color(1,1,1,0.3f);
            else 
                item.GetComponent<Image>().color = new Color(1,1,1,1f);
        }
    }   
}
