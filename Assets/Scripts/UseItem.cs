using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public string itemName;
    [SerializeField] ItemUI _itemUI;
    [SerializeField] GameObject bomb;
    public int healAmount, bombCount;
    public bool hpPotionAcquired, bombAcquired;
    public float coolDown;
    public void itemUse() {
        if (itemName == "HealthPotion" && coolDown <= 0) {
            healAmount = gameObject.GetComponent<PlayerStats>().Heal(healAmount);
            coolDown = 10;
            Debug.Log(healAmount);
        }
        else if (itemName == "Bomb") {
            if (bombCount > 0) {
                GameObject newBomb = Instantiate(bomb, transform.position, transform.rotation);
                bombCount--;
            }
        }
    }

    public void nextItem() {
        if (itemName == "Bomb" && hpPotionAcquired == true)
            itemName = "HealthPotion";
        else if (itemName == "HealthPotion" && bombAcquired == true)
            itemName = "Bomb";
    }
    // Start is called before the first frame update
    void Start()
    {
        healAmount = 25;
    }

    // Update is called once per frame
    void Update()
    {
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
