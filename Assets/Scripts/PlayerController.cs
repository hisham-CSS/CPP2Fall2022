using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;

    public float moveSpeed = 0;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;

    CharacterController controller;

    Vector3 curMoveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GetComponent<CharacterController>();
            controller.minMoveDistance = 0.0f;

            if (moveSpeed <= 0.0f)
            {
                moveSpeed = 6.0f;
                throw new ArgumentNullException("Movespeed Argument is null so the value has been defaulted to 6.0");
            }
        }

        catch (ArgumentNullException e)
        {
            Debug.Log(e.Message);
        }

        catch (UnassignedReferenceException e)
        {
            Debug.Log(e.Message);
        }

        finally
        {
            Debug.Log("This Code Always Runs");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            curMoveInput = transform.TransformDirection(curMoveInput);
        }

        curMoveInput.y -= gravity * Time.deltaTime;
        controller.Move(curMoveInput * Time.deltaTime);
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        //Debug.Log("Move vector is: " + context.action.ReadValue<Vector2>());
        Vector2 move = context.action.ReadValue<Vector2>();
        move.Normalize();

        Vector3 moveVel = new Vector3(move.x, 0, move.y);

        moveVel *= moveSpeed;
        curMoveInput = moveVel;   
    }

    public void Look(InputAction.CallbackContext context)
    {
        //Transform cameraTransform = Camera.main.transform;
        //Quaternion cameraRotation = cameraTransform.rotation;
        //cameraRotation.eulerAngles = new Vector3(0, cameraRotation.y, 0);
        //cameraTransform.rotation = cameraRotation;

        //Vector3 cameraFoward = cameraTransform.forward;

        //transform.rotation = Quaternion.LookRotation(-cameraFoward, Camera.main.transform.up);
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.action.WasPressedThisFrame())
        {
            Debug.Log("Fire Pressed");
        }
    }
}
