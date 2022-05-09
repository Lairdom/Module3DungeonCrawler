using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] HealthUI _hpUI;
    [SerializeField] KeysUI _keysUI;
    public int maxHealth, currentHealth;
    public int keys, damage;
    [SerializeField] AudioClip potionHeal;
    AudioSource source;
    GameObject UI;
    public bool invulnerable = false;
    public float invTimer = 0;
    int negateAmount;
    public bool dead;

    public void TakeDamage(int damage) {
        if (invulnerable != true) {
            if (negateAmount > 0) {
                negateAmount -= damage;
            }
            else {
                currentHealth -= (damage-negateAmount);
                negateAmount = 0;
                _hpUI.shieldIndicator(negateAmount);
            }
            _hpUI.alterHP(currentHealth, maxHealth);
            invulnerable = true;
            invTimer = 1.5f;
            if (currentHealth <= 0) {
                dead = true;
                Destroy(this.gameObject,1);
                UI.GetComponent<FadeToBlack>().FadeOut();
                UI.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            }
        }

    }

    public int Heal(int healAmount) {
        int overHeal = 0;
        if (healAmount < 75 )
            source.pitch = 1.2f;
        else
            source.pitch = 0.5f;
        // Play Heal Animation
        source.PlayOneShot(potionHeal);
        source.pitch = 1f;
        currentHealth += healAmount;
        if (currentHealth > maxHealth) {
            overHeal = currentHealth - maxHealth;
            currentHealth = maxHealth;
        }
        return overHeal;
    }

    public void Shield(int str) {
        source.pitch = 0.5f;
        source.PlayOneShot(potionHeal);
        source.pitch = 1f;
        negateAmount = str;
        _hpUI.shieldIndicator(negateAmount);
    }

    public void invFrames() {
        if (invTimer % 0.2f < 0.1f)
            GetComponent<SpriteRenderer>().enabled = false;
        else 
            GetComponent<SpriteRenderer>().enabled = true;
        if (invTimer <= 0) {
            invulnerable = false;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        invTimer -= Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        _hpUI.alterHP(currentHealth,maxHealth);
        _keysUI.showKeys(keys);
        source = GetComponent<AudioSource>();
        UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        _hpUI.alterHP(currentHealth, maxHealth);
        if (invulnerable == true)
            invFrames();
    }
}
