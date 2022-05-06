using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public Vector3 velocity;
    public GameObject mage;
    GameObject player;
    int damage;
    
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            player.GetComponent<PlayerStats>().TakeDamage(damage);
                
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        damage = mage.GetComponent<SkeletonMageAI>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else 
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        transform.position += velocity * Time.deltaTime;
        
    }
}
