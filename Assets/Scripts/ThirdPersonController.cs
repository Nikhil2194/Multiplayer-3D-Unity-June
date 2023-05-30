using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;
using Photon.Realtime;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed;
    public Transform cam;
    Animator anim;
    public PhotonView pv;
    public CinemachineVirtualCamera vcCam;
    void Start()
    {
        vcCam = FindObjectOfType<CinemachineVirtualCamera>();
        characterController = GetComponent<CharacterController>();
        anim =gameObject. GetComponent<Animator>();


        if (pv.IsMine)
        {
            vcCam.Follow = this.gameObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (pv.IsMine)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput);
            //  Vector3 movementDirection = movementInput.normalized;

            if (horizontalInput >= 1)
            {
                anim.SetTrigger("RightWalk");
            }
            else if (horizontalInput <= -1)
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

            characterController.Move(movementInput * moveSpeed * Time.deltaTime);
        }        
    }
}
