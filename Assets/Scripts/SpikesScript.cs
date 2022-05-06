using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    GameObject player;
    string direction;
    Vector3 dir;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            player.GetComponent<PlayerStats>().TakeDamage(10);
            direction = player.GetComponent<PlayerMovement>().direction;
            if (direction == "Up") 
                dir = transform.up;
            else if (direction == "Down")
                dir = -transform.up;
            else if (direction == "Left")
                dir = -transform.right;
            else if (direction == "Right")
                dir = transform.right;

            player.transform.position -= dir * 5f * Time.deltaTime;
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
