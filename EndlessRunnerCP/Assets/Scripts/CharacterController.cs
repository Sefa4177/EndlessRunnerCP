using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float slideSpeed;
    public float gravityScale;
    private bool isOnRight, isOnLeft;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isOnLeft = false;
        isOnRight = false;
    }
    void Update()
    {
        otonomMovement();
        MovementControl();
    }

    private void MovementControl()
    {
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(isOnRight || (!isOnLeft && !isOnRight))
            {
                rb.AddForce(Vector3.left * slideSpeed, ForceMode.Impulse);
                if(!isOnLeft && !isOnRight)
                {
                    isOnLeft = true;
                }
                isOnRight =false;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if(isOnLeft || (!isOnLeft && !isOnRight))
            {
                rb.AddForce(Vector3.right * slideSpeed, ForceMode.Impulse);
                rb.velocity = new Vector3(0f, rb.velocity.y, rb.velocity.z);
                if(!isOnLeft && !isOnRight)
                {
                    isOnRight = true;
                }
                isOnLeft =false;
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0f)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        
    }

    private void otonomMovement()
    {
        rb.AddForce(Vector3.forward * runSpeed, ForceMode.Force);
        rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Acceleration);

    }

    IEnumerator Wait(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
    }

}
