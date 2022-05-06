using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMageAI : MonoBehaviour
{
    GameObject player, newFire;
    [SerializeField] GameObject fire;
    public int fireSpeed, damage, maxHealth;
    public float fireRate = 2f;
    float timer;
    public Vector3 direction;

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
            if (distanceVector.magnitude <= 12) {
                if (gameObject.GetComponent<HealthManager>().stunned != true && timer > fireRate) {
                    //Skeleton Mage AI
                    gameObject.GetComponent<AudioSource>().Play();
                    newFire = Instantiate(fire, gameObject.transform);
                    Destroy(newFire, 4);
                    newFire.GetComponent<FireballMovement>().mage = this.gameObject;
                    FireballMovement moveFire = newFire.GetComponent<FireballMovement>();
                    moveFire.velocity = direction * fireSpeed;
                    timer = 0;
                }
                timer += Time.deltaTime;
                
            }
        }
    }
}
