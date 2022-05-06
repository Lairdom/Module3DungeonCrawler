using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] int healAmount;
    [SerializeField] string potionType;
    GameObject player;
    int overHeal;
    
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            if (potionType == "Heal") {
                overHeal = player.GetComponent<PlayerStats>().Heal(healAmount);
                if (player.GetComponent<UseItem>().itemName == "HealthPotion") {
                    player.GetComponent<UseItem>().healAmount += overHeal;
                }
            }
            if (potionType == "Shield")
                player.GetComponent<PlayerStats>().Shield(25);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
