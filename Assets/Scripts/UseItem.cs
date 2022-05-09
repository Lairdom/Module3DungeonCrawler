using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public string itemName;
    [SerializeField] ItemUI _itemUI;
    [SerializeField] GameObject bomb, coin;
    public int healAmount, bombCount, coinCount;
    public bool hpPotionAcquired, bombAcquired, coinAcquired;
    public bool thrownCoin;
    public float coolDown;
    public void itemUse() {
        if (itemName == "Coin" && coinCount > 0) {
            thrownCoin = true;
            GameObject newCoin = Instantiate(coin, transform.position, transform.rotation);
            coinCount--;
            thrownCoin = false;
        } 
        else if (itemName == "HealthPotion" && coolDown <= 0) {
            healAmount = gameObject.GetComponent<PlayerStats>().Heal(healAmount);
            coolDown = 10;
            Debug.Log(healAmount);
        }
        else if (itemName == "Bomb" && bombCount > 0) {
            GameObject newBomb = Instantiate(bomb, transform.position, transform.rotation);
            bombCount--;
        }
    }

    public void nextItem() {
        // Current item is Potion
        if (itemName == "HealthPotion" && bombAcquired == true)
            itemName = "Bomb";
        else if (itemName == "HealthPotion" && coinAcquired == true)
            itemName = "Coin";
        // Current item is Bomb
        else if (itemName == "Bomb" && coinAcquired == true)
            itemName = "Coin";
        else if (itemName == "Bomb" && hpPotionAcquired == true)
            itemName = "HealthPotion";
        // Current item is Coin
        else if (itemName == "Coin" && hpPotionAcquired == true)
            itemName = "HealthPotion";
        else if (itemName == "Coin" && bombAcquired == true)
            itemName = "Bomb"; 


    }
    // Start is called before the first frame update
    void Start()
    {
        healAmount = 25;
        thrownCoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemName == "Coin") {
            _itemUI.ChangeIcon("Coin");
                
        }
        
        if (coolDown > 0) 
            coolDown -= Time.deltaTime;
        if (itemName == "HealthPotion") {
            if (healAmount == 0) {
                _itemUI.ChangeIcon("EmptyPotion");
            }
            else if (healAmount <= 30) {
                _itemUI.ChangeIcon("HalfPotion");
            }
            else if (healAmount > 30) {
                if (healAmount > 50)
                    healAmount = 50;
                _itemUI.ChangeIcon("FullPotion");
            }
        }
        if (itemName == "Bomb") {
            _itemUI.ChangeIcon("Bomb");
        }
        
    }
}
