using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawns1 : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Sprite closeDoor;
    [SerializeField] Sprite openDoor;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject chest;
    GameObject newEnemy1, newEnemy2, newEnemy3, newEnemy4, newChest;
    
    bool triggered = false, rewarded = false;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            triggered = true;
            door.GetComponent<SpriteRenderer>().sprite = closeDoor;
            door.GetComponent<BoxCollider2D>().enabled = true;
            newEnemy1 = Instantiate(enemy, new Vector2(33,-31), transform.rotation);
            newEnemy2 = Instantiate(enemy, new Vector2(35,-36), transform.rotation);
            newEnemy3 = Instantiate(enemy, new Vector2(47,-30), transform.rotation);
            newEnemy4 = Instantiate(enemy, new Vector2(46,-38), transform.rotation);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
    void Reward() {
        door.GetComponent<SpriteRenderer>().sprite = openDoor;
        door.GetComponent<BoxCollider2D>().enabled = false;
        newChest = Instantiate(chest,new Vector2(44,-33),transform.rotation);
        newChest.GetComponent<ChestAnimation>().type = "SilverKeyChest";
        rewarded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true && rewarded != true
            && newEnemy1 == null 
            && newEnemy2 == null
            && newEnemy3 == null  
            && newEnemy4 == null)
                Reward();
    }
}
