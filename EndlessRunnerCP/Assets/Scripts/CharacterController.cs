using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float slideSpeed;
    public float gravityScale;
    private bool isMovementInProgress = false;
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
        //MovementControl();
        MovementControlDelayed();
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
        //sürekli olarak ileri gitmesini sağlayan kod.
        rb.AddForce(Vector3.forward * runSpeed, ForceMode.Force);

        //bu kodu yoruma aldım çünkü yerçekimini tam düzgün uygulayamıyordu.
        //rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Acceleration);

        //yerçekimi kuvveti
        rb.AddForce(Vector3.down * gravityScale * rb.mass);

    }

    private void MovementControlDelayed()
{
    if(isMovementInProgress) return;
    
    if(Input.GetKeyDown(KeyCode.A))
    {
        if(isOnRight || (!isOnLeft && !isOnRight))
            {
                isMovementInProgress = true;
                StartCoroutine(DoMovement(Vector3.left * slideSpeed));
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
                isMovementInProgress = true;
                StartCoroutine(DoMovement(Vector3.right * slideSpeed));
                if(!isOnLeft && !isOnRight)
                {
                    isOnRight = true;
                }
                isOnLeft =false;
            }
        
    }
    
    if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0f)
    {
        isMovementInProgress = true;
        StartCoroutine(DoMovement(Vector3.up * jumpSpeed));
    }
}

    private IEnumerator DoMovement(Vector3 direction)
{
    rb.AddForce(direction, ForceMode.Impulse);
    yield return new WaitForSeconds(.3f);
    isMovementInProgress = false;
}

    
}
