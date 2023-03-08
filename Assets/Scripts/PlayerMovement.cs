using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    public string direction;
    public bool attack, examine;
    Animator _animator;
    GameObject attackRange;
    bool pressedSwordButton;
    Vector2 playerInput;

    float delayTimer, itemDelay;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        attackRange = gameObject.transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _animator.SetFloat("PlayerWalkVertical",Input.GetAxis("Vertical"));
        _animator.SetFloat("PlayerWalkHorizontal",Input.GetAxis("Horizontal"));
        
        if (playerInput.y > 0 && delayTimer <= 0) {
            transform.position += transform.up * 
                (Mathf.Abs(Input.GetAxis("Vertical")) * moveSpeed) * Time.deltaTime;
            if (Mathf.Abs(playerInput.y) > Mathf.Abs(playerInput.x)) {
                _animator.Play("PlayerWalkUp");
                direction = "Up";
                attackRange.transform.localPosition = new Vector2(0,0f);
                attackRange.transform.localRotation = Quaternion.Euler(0,0,180);
            }
        }
        if (playerInput.y < 0 && delayTimer <= 0) {
            transform.position -= transform.up * 
                (Mathf.Abs(Input.GetAxis("Vertical")) * moveSpeed) * Time.deltaTime;
            if (Mathf.Abs(playerInput.y) > Mathf.Abs(playerInput.x)) {
                _animator.Play("PlayerWalkDown");
                direction = "Down";
                attackRange.transform.localPosition = new Vector2(0,0f);
                attackRange.transform.localRotation = Quaternion.Euler(0,0,0);
            }
        } 
        if (playerInput.x < 0 && delayTimer <= 0) {
            transform.position -= transform.right * 
                (Mathf.Abs(Input.GetAxis("Horizontal")) * moveSpeed) * Time.deltaTime;
            if (Mathf.Abs(playerInput.x) > Mathf.Abs(playerInput.y)) {
                _animator.Play("PlayerWalkLeft");
                direction = "Left";
                attackRange.transform.localPosition = new Vector2(0f,0f);
                attackRange.transform.localRotation = Quaternion.Euler(0,0,270);
            }
        }
        if (playerInput.x > 0 && delayTimer <= 0) {
            transform.position += transform.right * 
                (Mathf.Abs(Input.GetAxis("Horizontal")) * moveSpeed) * Time.deltaTime;
            if (Mathf.Abs(playerInput.x) > Mathf.Abs(playerInput.y)) {
                _animator.Play("PlayerWalkRight");
                direction = "Right";
                attackRange.transform.localPosition = new Vector2(0f,0f);
                attackRange.transform.localRotation = Quaternion.Euler(0,0,90);
            }
        }
    }
    void Update() {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("NextItem") || Input.GetButtonDown("Controller-NextItem")) {
            gameObject.GetComponent<UseItem>().nextItem();
        }
        _animator.SetBool("PlayerAttack",Input.GetButtonDown("Attack"));
        if (Input.GetButtonDown("Attack") || Input.GetButtonDown("Controller-Attack")) {
            if (delayTimer <= 0f) {
                transform.GetChild(0).gameObject.GetComponent<AudioSource>().Play();
                if (direction == "Up") {
                    _animator.Play("PlayerSlashUp");
                }
                if (direction == "Down") {
                    _animator.Play("PlayerSlashDown");
                }
                if (direction == "Left") {
                    _animator.Play("PlayerSlashLeft");
                }
                if (direction == "Right") {
                    _animator.Play("PlayerSlashRight");
                }
                attack = true;
                delayTimer = 0.5f;
            }
        }

        if (Input.GetButtonDown("UseItem") || Input.GetButtonDown("Controller-UseItem")) {
            if (delayTimer <= 0f && itemDelay <= 0) {
                gameObject.GetComponent<UseItem>().itemUse();
                itemDelay = 1f;
            }
        }
        
        if (Input.GetButtonDown("Examine") || Input.GetButtonDown("Controller-Examine")) {
            examine = true;
        }

        if (Input.GetButtonDown("Quit")) {
            Application.Quit();
        }
        delayTimer -= Time.deltaTime;
        itemDelay -= Time.deltaTime;
    }

}
