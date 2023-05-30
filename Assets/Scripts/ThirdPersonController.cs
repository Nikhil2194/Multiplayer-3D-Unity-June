using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed;
    public Transform cam;
    Animator anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim =gameObject. GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        if(horizontalInput>=1 )
        {
            anim.SetTrigger("RightWalk");
        }
        else if ( horizontalInput <=-1)
        {
            anim.SetTrigger("LeftWalk");
        }    
        else if (verticalInput >= 1)
        {
            anim.SetTrigger("FrontWalk");
        }
        else if (verticalInput <= -1)
        {
            anim.SetTrigger("BackWalk");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
      
        characterController.Move(movementDirection * moveSpeed * Time.deltaTime);
    }
}
