using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] float bombTimer;
    [SerializeField] Sprite bomb2;
    [SerializeField] AudioClip explosion;
    Animator _animator;
    GameObject player;
    bool exploded;

    private void OnTriggerStay2D(Collider2D col) {
        if (gameObject.name != "BombPickup") {
            if (col.gameObject.tag == "Enemy" && col.GetComponent<HealthManager>().invulnerable != true) {
                
                col.gameObject.GetComponent<HealthManager>().EnemyTakeDamage(50);
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
            if (col.gameObject.tag == "Player") {
                col.gameObject.GetComponent<PlayerStats>().TakeDamage(25);
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }

    IEnumerator BombExplosion() {
        _animator.enabled = true;
        player.GetComponent<AudioSource>().PlayOneShot(explosion);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject,0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bombTimer = 3f;
        _animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "BombPickup") {
            if (gameObject.GetComponent<Activate>().activate == true) {
                player.GetComponent<UseItem>().itemName = "Bomb";
                player.GetComponent<UseItem>().bombAcquired = true;
                player.GetComponent<UseItem>().bombCount = 10;
                // Play Sound
                Destroy(this.gameObject,1);
            }
        }
        else {
            if (bombTimer > 0)
                bombTimer -= Time.deltaTime;
            if (bombTimer < 1.5f && bombTimer > 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = bomb2;
            }
            else if (bombTimer <= 0 && exploded != true) {
                StartCoroutine("BombExplosion");
                exploded = true;
            }
            
        }
    }
}
