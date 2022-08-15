using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPlayer3D : MonoBehaviour
{
    public float playerHeight = 1f;

    [Header("Movement")]
    [SerializeField]float moveSpeed = 6f;
    [SerializeField]float airMultiplier = 0.12f;
    [SerializeField]float movementMultiplier = 10f;

    [Header("Jump keybind")]
    KeyCode jumpKey = KeyCode.Space;

    [Header("Jumping")]
    [SerializeField]float jumpForce = 100f;
    
    [Header("Drag")]
    [SerializeField]float groundDrag = 6f;
    [SerializeField]float airDrag = 2f;

    [Header("Texts")]
    public TextMeshProUGUI countText;
    private int coinCount;

    private float horizontalMovement;
    private float verticalMovement;

    bool isGrounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        coinCount = 0;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.05f);
        

        MyInput();
        ControlDrag();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }

        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }

    void SetCountText()
    {
        countText.text = coinCount.ToString();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCount = coinCount + 10;
            SetCountText();
            Debug.Log(coinCount);
        }
        

        

        
    }
}