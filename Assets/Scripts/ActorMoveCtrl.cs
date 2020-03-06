using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMoveCtrl : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (controller.isGrounded)
        // {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        // }
        controller.Move(moveDirection * Time.deltaTime);
        controller.gameObject.transform.Rotate(new Vector3(0,1*Time.deltaTime,0)); 
    }
}