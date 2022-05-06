using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthUI : MonoBehaviour
{
    [SerializeField] GameObject hpBar;
    public void alterHP(int currentHP, int maxHP)
    {
        RectTransform rt = hpBar.GetComponent<RectTransform>();
        float bar = Script.Remap(0,maxHP,0,1000,currentHP);
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
