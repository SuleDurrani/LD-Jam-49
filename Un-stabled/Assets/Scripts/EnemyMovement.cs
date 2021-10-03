using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 10f;
    private CharacterController2D controller;
    private float horizontalMove = 0f;
    private bool jump;
    public Transform target;
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
        float targetDirection = transform.position.x - target.position.x;
        targetDirection = targetDirection > 0 ? -1 : 1;
        horizontalMove = targetDirection * runSpeed;
        jump = Random.Range(0f,1f) > .95f;
    }

    // FixedUpdate is called once per tick
    void FixedUpdate() {
        animator.SetBool("walking",Mathf.Abs(horizontalMove)>0.01f);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
}
