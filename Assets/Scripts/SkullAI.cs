using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAI : MonoBehaviour
{
    GameObject player;
    public int moveSpeed, damage, maxHealth;
    Vector3 direction, startPoint, endPoint;
    float t;

    bool lerping;
    private void OnTriggerStay2D(Collider2D col) {
        if (col.name == "Player") {
            if (gameObject.GetComponent<HealthManager>().stunned != true)
                player.GetComponent<PlayerStats>().TakeDamage(damage);
        }       
    }


    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        gameObject.GetComponent<HealthManager>().currentHealth = maxHealth;
    }

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
            if (distanceVector.magnitude <= 10 
            && gameObject.GetComponent<HealthManager>().stunned != true) {
                if (gameObject.GetComponent<HealthManager>().invulnerable != true) {
                    gameObject.GetComponent<AudioSource>().Play();
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
                else {
                    gameObject.GetComponent<HealthManager>().stunned = true;
                     transform.position = Vector2.Lerp(
                             transform.position, transform.position - direction * 2, 1);
                    t += Time.deltaTime * 0.5f;

                }
            }
        }
    }
}
