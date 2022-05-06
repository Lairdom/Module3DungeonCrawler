using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    float t;
    public IEnumerator showLocked() {
        t = 0f;
        text.enabled = true;
        yield return new WaitForSeconds(2f);
        text.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (text.enabled == true) {
            transform.localPosition = Vector2.Lerp(Vector2.zero, new Vector2(0,120), t/2);
            //text.transform.position = Vector2.Lerp(Vector2.zero, new Vector2(0,50), 5 * Time.deltaTime);
        }
        t += Time.deltaTime;
    }
}
