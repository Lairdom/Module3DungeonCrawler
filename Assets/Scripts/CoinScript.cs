using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    GameObject player;
    bool thrown;
    string direction;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && thrown == false) {
            Debug.Log("Coin collected");
            Destroy(gameObject);
        }
        if (col.tag == "Enemy" && thrown == true) {
            col.gameObject.GetComponent<HealthManager>().EnemyTakeDamage(3);
            Destroy(gameObject);
        }
        if (col.name == "WireTrigger1" && thrown == true) {
            Debug.Log("Triggered");
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        thrown = player.GetComponent<UseItem>().thrownCoin;
        direction = player.GetComponent<PlayerMovement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "Up" && thrown == true) {
            transform.position += transform.up * 10 * Time.deltaTime;
        }
        if (direction == "Down" && thrown == true) {
            transform.position -= transform.up * 10 * Time.deltaTime;
        }
        if (direction == "Left" && thrown == true) {
            transform.position -= transform.right * 10 * Time.deltaTime;
        }
        if (direction == "Right" && thrown == true) {
            transform.position += transform.right * 10 * Time.deltaTime;
        }
        
    }
}
