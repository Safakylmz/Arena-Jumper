using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2D : MonoBehaviour
{
    [Header("Particle Effects")]
    public ParticleSystem jumpingParticle;
    public ParticleSystem jetpackParticle;
    public ParticleSystem bloodParticle;

    [Header("Left or Right movement speed")]
    public float movementSpeed = 10f;
    float movement = 0f;

    [Header("Coin Count Text")]
    public TextMeshProUGUI countText;
    private int coinCount;
    
    Rigidbody2D rb;

    // karakter seçme ekranýnýn oyuna yansýmasý için.
    [Header("Karakter havuzu ve karakter sprite")]
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    [Header("Saða gidip soldan çýkma, sola gidip saðdan çýkma,endless")]
    public GameObject leftObj;
    public GameObject rightObj;
    
    
    [Header("Jetpack Options")]
    public float secondsToApplyForce = 5;
    private bool addingForce;
    public float jetpackPower = 40;
    private float timeCount;
    [SerializeField] private float customDrag;


    private int selectedOption = 0;  //karakter seçme ekraný seçilen karakter 0.
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        rb = GetComponent<Rigidbody2D>();
        coinCount = 0;

    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

    }
    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;


        if (addingForce)
        {
            timeCount += Time.deltaTime;

            if (timeCount < secondsToApplyForce)
            {
                rb.AddForce(Vector2.up * jetpackPower, ForceMode2D.Force);
                rb.drag = customDrag;
                jetpackParticle.Play();
            }
            else
            {
                timeCount = 0;
                addingForce = false;
                rb.drag = 0;
                jetpackParticle.Stop();
            }
        }
    }
    void SetCountText()
    {
        countText.text = coinCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCount = coinCount + 30;
            SetCountText();
            
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {

            Destroy(collision.gameObject);
            addingForce = true;
            rb.velocity = Vector2.up;


        }

        if (collision.CompareTag("Left"))
        {
            this.transform.position = new Vector3(rightObj.transform.position.x - 2, this.transform.position.y, this.transform.position.z);
        }
        if (collision.CompareTag("Right"))
        {
            this.transform.position = new Vector3(leftObj.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
        }

        if (collision.CompareTag("Collider"))
        {
            GameManager2D.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    public void CreateDust()
    {
        jumpingParticle.Play();
    }

    public void CreateBlood()
    {
        bloodParticle.Play();
    }

    /*
    void JetpackEffect()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(Vector2.up * jetpackPower, ForceMode2D.Force);
        }
    }
    */

}
