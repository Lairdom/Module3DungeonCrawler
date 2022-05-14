using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullBossAI : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip bossMusic;
    [SerializeField] BossHealthUI _hpUI;
    [SerializeField] GameObject skull;
    public Image hpBarLeft, hpBarRight, hpBarMiddle, hpBar;
    GameObject player, tempEnemy1, tempEnemy2, tempEnemy3, tempEnemy4;
    GameObject newSkull1, newSkull2, newSkull3, newSkull4;
    public int moveSpeed, damage, maxHealth;
    Vector3 direction, scaleChange, skullsPosition;
    bool transformed, moveEnemy1, moveEnemy2, moveEnemy3, moveEnemy4, lerping;
    int currentHealth;
    float specialCooldown, t;
    
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
        tempEnemy2.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(2f);
        Destroy(tempEnemy1);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy2.GetComponent<SpriteRenderer>().enabled = false;
        moveEnemy3 = true;
        tempEnemy3.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(2f);
        Destroy(tempEnemy2);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy3.GetComponent<SpriteRenderer>().enabled = false;
        moveEnemy4 = true;
        tempEnemy4.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(2f);
        Destroy(tempEnemy3);
        transform.localScale += scaleChange;
        gameObject.GetComponent<AudioSource>().Play();
        tempEnemy4.GetComponent<SpriteRenderer>().enabled = false;
        source.PlayOneShot(bossMusic);
        hpBarLeft.enabled = true;
        hpBarRight.enabled = true;
        hpBarMiddle.enabled = true;
        hpBar.enabled = true;
        Destroy(tempEnemy4,2f);
        BossHealthBar();
    }

    IEnumerator TriggerSpecialAttack() {
        gameObject.GetComponent<HealthManager>().stunned = true;
        yield return new WaitForSeconds(0.2f);
        scaleChange = new Vector3(0.2f,0.2f,0);
        transform.localScale -= scaleChange;
        yield return new WaitForSeconds(0.6f);
        transform.localScale += scaleChange*2;
        skullsPosition = transform.position;
        newSkull1 = Instantiate(skull, transform.position, transform.rotation);
        newSkull1.GetComponent<SkullAI>().enabled = false;
        newSkull2 = Instantiate(skull, transform.position, transform.rotation);
        newSkull2.GetComponent<SkullAI>().enabled = false;
        newSkull3 = Instantiate(skull, transform.position, transform.rotation);
        newSkull3.GetComponent<SkullAI>().enabled = false;
        newSkull4 = Instantiate(skull, transform.position, transform.rotation);
        newSkull4.GetComponent<SkullAI>().enabled = false;
        lerping = true;
        t = 0;
        yield return new WaitForSeconds(0.6f);
        transform.localScale -= scaleChange;
        yield return new WaitForSeconds(1f);
        lerping = false;
        newSkull1.GetComponent<SkullAI>().enabled = true;
        newSkull1.GetComponent<SkullAI>().moveSpeed = 3;
        newSkull2.GetComponent<SkullAI>().enabled = true;
        newSkull2.GetComponent<SkullAI>().moveSpeed = 3.2f;
        newSkull3.GetComponent<SkullAI>().enabled = true;
        newSkull3.GetComponent<SkullAI>().moveSpeed = 2.8f;
        newSkull4.GetComponent<SkullAI>().enabled = true;
        newSkull1.GetComponent<SkullAI>().moveSpeed = 3.1f;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<HealthManager>().stunned = false;
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
            if (currentHealth < 75 && specialCooldown <= 0 && distanceVector.magnitude > 3) {
                // StartCoroutine(TriggerSpecialAttack());
                specialCooldown = Random.Range(15,30);
                Debug.Log(specialCooldown);
            }
            if (newSkull1 != null && lerping) {
                newSkull1.transform.position = Vector2.Lerp(skullsPosition,
                    new Vector2(transform.position.x-2, transform.position.y+2), t);
            }
            if (newSkull2 != null && lerping) {
                newSkull2.transform.position = Vector2.Lerp(skullsPosition,
                    new Vector2(transform.position.x+2, transform.position.y+2), t);
            }
            if (newSkull3 != null && lerping) {
                newSkull3.transform.position = Vector2.Lerp(skullsPosition,
                    new Vector2(transform.position.x-2, transform.position.y-2), t);
            }
            if (newSkull4 != null && lerping) {
                newSkull4.transform.position = Vector2.Lerp(skullsPosition,
                    new Vector2(transform.position.x+2, transform.position.y-2), t);
            }
            t += Time.deltaTime*8;
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
