using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] float bombTimer;
    [SerializeField] Sprite bomb2;
    [SerializeField] AudioClip explosion, pickUp;
    MessageUI _messageUI;
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
            if (col.name == "BreakableWall") {
                col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                col.gameObject.GetComponent<Collider2D>().enabled = false;
                col.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    IEnumerator BombExplosion() {
        _animator.enabled = true;
        player.GetComponent<AudioSource>().PlayOneShot(explosion);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject,0.4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bombTimer = 3f;
        _animator = gameObject.GetComponent<Animator>();
        _messageUI = GameObject.Find("Message").GetComponent<MessageUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "BombPickup") {
            if (gameObject.GetComponent<Activate>().activate == true) {
                player.GetComponent<UseItem>().itemName = "Bomb";
                player.GetComponent<UseItem>().bombAcquired = true;
                player.GetComponent<UseItem>().bombCount = 10;
                _messageUI.setMessage("10 Bombs Obtained");
                StartCoroutine(_messageUI.showMessage());
                player.GetComponent<AudioSource>().volume = 0.1f;
                player.GetComponent<AudioSource>().PlayOneShot(pickUp);
                player.GetComponent<AudioSource>().volume = 0.2f;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(this.gameObject,2);
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
