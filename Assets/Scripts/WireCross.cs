using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCross : MonoBehaviour
{
    GameObject player;

    
    //private void OnTriggerEnter2D(Collider2D col) {
    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Coin(Clone)") {
            player.transform.position = transform.position;
            Debug.Log("Toimii");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
