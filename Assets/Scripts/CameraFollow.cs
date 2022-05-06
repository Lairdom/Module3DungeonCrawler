using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null) {
            if (Input.GetButton("Jump")) {
                if (Vector2.Distance(transform.position,player.transform.position) <= 5) {
                    transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),
                    Input.GetAxisRaw("Vertical"),-15) * 5 * Time.deltaTime;
                }
            }
            else
                transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-15);
        }
        
    }
}
