using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    
    [SerializeField] GameObject hpBar;
    [SerializeField] Sprite normalBar, shieldBar;
    
    public void shieldIndicator(int negateAmount)
    {
        if (negateAmount > 0) {
            hpBar.GetComponent<Image>().sprite = shieldBar;
        }
        else
            hpBar.GetComponent<Image>().sprite = normalBar;
    }   

    public void alterHP(int currentHP, int maxHP)
    {
        RectTransform rt = hpBar.GetComponent<RectTransform>();
        float bar = Script.Remap(0,maxHP,0,500,currentHP);
        rt.sizeDelta = new Vector2(bar,80);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
