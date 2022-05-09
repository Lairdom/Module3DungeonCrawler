using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallScript : MonoBehaviour
{
    MessageUI _messageUI;
    // Start is called before the first frame update
    void Start()
    {
        _messageUI = GameObject.Find("Message").GetComponent<MessageUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Activate>().activate == true) {
            Debug.Log("I can feel air coming from behind this wall");
            _messageUI.setMessage("Looks breakable");
            StartCoroutine(_messageUI.showMessage());
        }
        gameObject.GetComponent<Activate>().activate = false;
    }
}
