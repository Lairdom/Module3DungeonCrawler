using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    GameObject player;
    public float invTimer;
    public bool invulnerable = false, stunned = false;
    public int currentHealth;
    
    public void invFrames() {
        if (invTimer % 0.2f < 0.1f)
            GetComponent<SpriteRenderer>().enabled = false;
        else 
            GetComponent<SpriteRenderer>().enabled = true;
            
        if (invTimer <= 0) {
            invulnerable = false;
            stunned = false;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        
        invTimer -= Time.deltaTime;
    }
    public void EnemyTakeDamage(int dmg) {
        currentHealth -= dmg;
        invTimer = 1;
        invulnerable = true;
        if (currentHealth <= 0) {
            invFrames();
            stunned = true;
            Destroy(gameObject,1);
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
        if (invulnerable == true)
            invFrames();
        
    }
}
