using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Definitions
    [SerializeField] private float jumpForce = 10f; // zıplama kuvveti
    [SerializeField] private float extraGravityMultiplier = 0.6f;
    [SerializeField] private float moveSpeed = 5f; // hareket hızı
    [SerializeField] private float runSpeed;
    [SerializeField] private float gravityScale;
    private int laneIndex = 1; // başlangıçta orta şeritte olacak
    private float laneDistance = 3.5f; // şeritler arası mesafe
    private float leftLaneX = -3.5f; // sol şeridin X değeri
    private float rightLaneX = 3.5f; // sağ şeridin X değeri
    private float lastSwipeTime = 0f; // son swipe zamanı
    private bool isGrounded = true; // zemine temas halinde mi?
    private float speedIncreaseRate = 0.01f; // hız artış oranı (saniyede %1)
    private float speedIncreaseTimer = 0f; // hız artışını sayacak zamanlayıcı

    Animator animatorController;
    Rigidbody rb;
    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        animatorController = GetComponent<Animator>();
    }
    void Update()
    {   
        otonomMovement();
        MovementControl();
        IncreasedSpeed();
    }
    

    #region Methods
    private void otonomMovement() //oyun başlar başlamaz otonom şekilde olacak hareketler.
    {
        //sürekli olarak ileri gitmesini sağlayan kod.
        rb.AddForce(Vector3.forward * runSpeed *Time.deltaTime, ForceMode.Force);

        //bu kodu yoruma aldım çünkü yerçekimini tam düzgün uygulayamıyordu.
        //rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Acceleration);

        //yerçekimi kuvveti
        float verticalVelocity = rb.velocity.y;
        rb.AddForce(Vector3.down * gravityScale * rb.mass * Time.deltaTime);
        if (verticalVelocity < 0)
        {
            // Yere doğru düşüyorsak, yerçekimi kuvvetini arttırarak daha hızlı düşmemizi sağlayabiliriz.
             rb.AddForce(Vector3.down * gravityScale * rb.mass * extraGravityMultiplier * Time.deltaTime);
        }
    }
private void MovementControl()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved && Time.time - lastSwipeTime > 0.2f)
        {
            Vector2 deltaPosition = touch.deltaPosition;
            if (deltaPosition.y > 0f && Mathf.Abs(deltaPosition.y) > Mathf.Abs(deltaPosition.x))
            {
                Jump();
            }
            else if (deltaPosition.x < 0f)
            {
                // sol şeride git
                if (laneIndex > 0)
                {
                    laneIndex--;
                    lastSwipeTime = Time.time;
                }
            }
            else if (deltaPosition.x > 0f)
            {
                // sağ şeride git
                if (laneIndex < 2)
                {
                    laneIndex++;
                    lastSwipeTime = Time.time;
                }
            }
        }

        if (touch.phase == TouchPhase.Ended)
        {
            // parmak ekranın üzerinden kaldırıldı
            StopMoving();
        }
    }

    // karakteri hedef pozisyona hareket ettir
    Vector3 targetPosition = new Vector3(GetLaneXPosition(laneIndex), transform.position.y, transform.position.z);
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
}

private void StopMoving()
{
    // karakterin hareketini durdur
    StopAllCoroutines();
}

private float GetLaneXPosition(int laneIndex)
{
    // verilen şerit index'ine göre X pozisyonunu hesapla
    switch (laneIndex)
    {
        case 0:
            return leftLaneX;
        case 1:
            return 0f;
        case 2:
            return rightLaneX;
        default:
            return 0f;
    }
}

private void Jump()
{
    if (isGrounded)
    {   
        animatorController.SetTrigger("Jump");//animasyonu çalıştır
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);// zıplama kuvvetini objeye uygula
        isGrounded = false;
    }
}

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        // obje zemine temas etti, zıplama işlemi yapılabilir
        animatorController.SetBool("IsGrounded",true);
        isGrounded = true;
    }
}

    private void IncreasedSpeed() // oyundaki karakterin hızını gittikçe arttırmak için kod.
    {
        // zamanlayıcıyı arttır
    speedIncreaseTimer += Time.deltaTime;

    // zamanlayıcı 1 saniyeyi geçtiyse hızı arttır
    if (speedIncreaseTimer >= 1f)
    {
        GameButtons.Instance.score +=1;
        runSpeed += runSpeed * speedIncreaseRate;
        speedIncreaseTimer = 0f;
    }

    }

    #endregion
}
