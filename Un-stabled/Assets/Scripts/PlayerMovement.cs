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

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        jumpAxis = Input.GetAxisRaw("Jump");
    }

    // FixedUpdate is called once per tick
    void FixedUpdate() {
        controller.Move((horizontalMove * (rageMode?1.2f:1f)) * Time.fixedDeltaTime, false, jumpAxis > 0);
    }
}
