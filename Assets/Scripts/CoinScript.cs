using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    GameObject player;
    bool thrown;
    string direction;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && thrown != false) {
            // increase money
            Destroy(gameObject);
        }
        // if (col.tag == "Enemy" && thrown == true) {
        //     col.gameObject.GetComponent<HealthManager>().EnemyTakeDamage(3);
        //     thrown = false;
        // }
        // if (col.name == "WireTrigger1") {
        //     Debug.Log("Triggered");
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        // thrown = player.GetComponent<UseItem>().thrownCoin;
        direction = player.GetComponent<PlayerMovement>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        // if (direction == "Up") {
        //     transform.position += transform.up * 10 * Time.deltaTime;
        // }
        // if (direction == "Down") {
        //     transform.position -= transform.up * 10 * Time.deltaTime;
        // }
        // if (direction == "Left") {
        //     transform.position -= transform.right * 10 * Time.deltaTime;
        // }
        // if (direction == "Right") {
        //     transform.position += transform.right * 10 * Time.deltaTime;
        // }
    }
}
