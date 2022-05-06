using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExamine : MonoBehaviour
{
    GameObject player;
    
    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Interactable" && player.GetComponent<PlayerMovement>().examine == true) {
            col.gameObject.GetComponent<Activate>().activate = true;
        }
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().examine = false;
    }

    IEnumerator turnOffCollider() {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().examine = false;
    }

    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        if (player.GetComponent<PlayerMovement>().examine == true) {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            StartCoroutine(turnOffCollider());
        }
    }
}
