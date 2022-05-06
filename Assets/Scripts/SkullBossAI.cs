using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullBossAI : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip bossMusic;
    [SerializeField] BossHealthUI _hpUI;
    public Image hpBarLeft, hpBarRight, hpBarMiddle, hpBar;
    GameObject player, tempEnemy1, tempEnemy2, tempEnemy3, tempEnemy4;
    public int moveSpeed, damage, maxHealth;
    Vector3 direction, scaleChange;
    bool transformed, moveEnemy1, moveEnemy2, moveEnemy3, moveEnemy4;
    int currentHealth;
    
    private void OnTriggerStay2D(Collider2D col) {
        if (col.name == "Player") {
            if (gameObject.GetComponent<HealthManager>().stunned != true) {
                gameObject.GetComponent<AudioSource>().Play();
                player.GetComponent<PlayerStats>().TakeDamage(damage);
            }
        }       
    }
    void BossHealthBar() {
        _hpUI.alterHP(currentHealth, maxHealth);
    }
    IEnumerator TriggerTransformation() {
        source.Stop();
        gameObject.GetComponent<HealthManager>().stunned = true;
        gameObject.GetComponent<HealthManager>().invulnerable = true;
        gameObject.GetComponent<HealthManager>().invTimer = 10;
        tempEnemy1.GetComponent<SpriteRenderer>().enabled = true;
        tempEnemy2.GetComponent<SpriteRenderer>().enabled = true;
        tempEnemy3.GetComponent<SpriteRenderer>().enabled = true;
        tempEnemy4.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<AudioSource>().Play();
        moveEnemy1 = true;
        yield return new WaitForSeconds(2f);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy1.GetComponent<SpriteRenderer>().enabled = false;
        moveEnemy2 = true;
        yield return new WaitForSeconds(2f);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy2.GetComponent<SpriteRenderer>().enabled = false;
        moveEnemy3 = true;
        yield return new WaitForSeconds(2f);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy3.GetComponent<SpriteRenderer>().enabled = false;
        moveEnemy4 = true;
        yield return new WaitForSeconds(2f);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy4.GetComponent<SpriteRenderer>().enabled = false;
        source.PlayOneShot(bossMusic);
        hpBarLeft.enabled = true;
        hpBarRight.enabled = true;
        hpBarMiddle.enabled = true;
        hpBar.enabled = true;
        BossHealthBar();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        tempEnemy1 = transform.GetChild(0).gameObject;
        tempEnemy2 = transform.GetChild(1).gameObject;
        tempEnemy3 = transform.GetChild(2).gameObject;
        tempEnemy4 = transform.GetChild(3).gameObject;
        gameObject.GetComponent<HealthManager>().currentHealth = maxHealth;
        transformed = false;
        scaleChange = new Vector3(1f,1f,0);
        source = GameObject.Find("UI").GetComponent<AudioSource>();
        currentHealth = maxHealth;
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
            if (gameObject.GetComponent<HealthManager>().stunned != true) {
                gameObject.GetComponent<AudioSource>().Play();
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
        
        // UI Management
        currentHealth = gameObject.GetComponent<HealthManager>().currentHealth;
        BossHealthBar();
        if (currentHealth <= 0) {
            gameObject.GetComponent<SkullBossAI>().hpBarLeft.enabled = false;
            gameObject.GetComponent<SkullBossAI>().hpBarRight.enabled = false;
            gameObject.GetComponent<SkullBossAI>().hpBarMiddle.enabled = false;
            gameObject.GetComponent<SkullBossAI>().hpBar.enabled = false;
        }

        //Transformation
        if (transformed == false && gameObject.GetComponent<HealthManager>().currentHealth < maxHealth) {
            gameObject.GetComponent<HealthManager>().stunned = true;
            transform.position = Vector2.Lerp(transform.position, transform.position - direction * 2, 1);
            StartCoroutine(TriggerTransformation());
            transformed = true;
        }
        if (moveEnemy1 == true) {
            tempEnemy1.transform.localPosition = Vector3.MoveTowards(tempEnemy1.transform.localPosition
            , new Vector3(0,0,0), 12 * Time.deltaTime);
            if (tempEnemy1.transform.localPosition == new Vector3(0,0,0))
                moveEnemy1 = false;
        }
        if (moveEnemy2 == true) {
            tempEnemy2.transform.localPosition = Vector3.MoveTowards(tempEnemy2.transform.localPosition
            , new Vector3(0,0,0), 12 * Time.deltaTime);
            if (tempEnemy2.transform.localPosition == new Vector3(0,0,0))
                moveEnemy2 = false;
        }
        if (moveEnemy3 == true) {
            tempEnemy3.transform.localPosition = Vector3.MoveTowards(tempEnemy3.transform.localPosition
            , new Vector3(0,0,0), 12 * Time.deltaTime);
            if (tempEnemy3.transform.localPosition == new Vector3(0,0,0))
                moveEnemy3 = false;
        }
        if (moveEnemy4 == true) {
            tempEnemy4.transform.localPosition = Vector3.MoveTowards(tempEnemy4.transform.localPosition
            , new Vector3(0,0,0), 12 * Time.deltaTime);
            if (tempEnemy4.transform.localPosition == new Vector3(0,0,0))
                moveEnemy4 = false;
        }
            
    }
}
