using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKnightAI : MonoBehaviour
{
    GameObject player;
    public int moveSpeed, damage, maxHealth;
    Vector3 direction;

    private void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.name == "Player") {
            if (gameObject.GetComponent<HealthManager>().stunned != true)
                player.GetComponent<PlayerStats>().TakeDamage(damage);    
        

        }       
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        gameObject.GetComponent<HealthManager>().currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            Vector3 distanceVector = player.transform.position - transform.position;
            direction = distanceVector.normalized;
            if (direction.x < 0) {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            if (distanceVector.magnitude <= 10) {
                if (gameObject.GetComponent<HealthManager>().stunned != true) {
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
            }
        }
    }
}
