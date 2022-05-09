using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    float t;
    public IEnumerator showMessage() {
        t = 0f;
        message.enabled = true;
        yield return new WaitForSeconds(2f);
        message.enabled = false;
        transform.localPosition = Vector2.zero;
    }

    public void setMessage(string newMessage) {
        message.text = newMessage;
    }
    
    void Start()
    {
        message.enabled = false;
    }

    void Update()
    {
        if (message.enabled == true) {
            transform.localPosition = Vector2.Lerp(Vector2.zero, new Vector2(0,120), t/2);
        }
        t += Time.deltaTime;
    }
}
