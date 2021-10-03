using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 40f;
    private CharacterController2D controller;
    private float horizontalMove = 0f;
    private float jumpAxis;
    private bool rageMode = false;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        jumpAxis = Input.GetAxisRaw("Jump");
        if (transform.position.y < -100)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,110,0), Vector2.down, Mathf.Infinity);
            if (hit.collider.gameObject.layer == 3)
            {
                transform.position = hit.transform.position + new Vector3(0,2.5f,0);
            }else{
                transform.position = new Vector3(0,0.5f,0);
            }
            GetComponent<Rigidbody2D>().velocity = Vector2.up;
        }
    }

    // FixedUpdate is called once per tick
    void FixedUpdate() {
        animator.SetBool("walking",Mathf.Abs(horizontalMove)>0.01f);
        controller.Move((horizontalMove * (rageMode?1.2f:1f)) * Time.fixedDeltaTime, false, jumpAxis > 0);
    }
}
