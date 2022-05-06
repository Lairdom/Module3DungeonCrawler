using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    int damage;
    GameObject player;
    string direction;
    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy" 
        && player.GetComponent<PlayerMovement>().attack == true
        && col.GetComponent<HealthManager>().invulnerable != true) {
            col.GetComponent<HealthManager>().EnemyTakeDamage(damage);
        }
        //StartCoroutine(turnOffCollider());
    }

    IEnumerator turnOffCollider() {
        yield return new WaitForSeconds(0.6f);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().attack = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
        damage = player.GetComponent<PlayerStats>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().attack == true) {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            StartCoroutine(turnOffCollider());
        }
    }
}
