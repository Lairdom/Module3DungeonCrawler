using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    public void showKeys(int keys)
    {
        textComponent.text = "Keys: "+keys;
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
