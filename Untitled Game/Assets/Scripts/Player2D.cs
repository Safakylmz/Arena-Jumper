using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2D : MonoBehaviour
{
    public float movementSpeed = 10f;
    float movement = 0f;
    public TextMeshProUGUI countText;
    private int coinCount;

    Rigidbody2D rb;
    // karakter seçme ekranýnýn oyuna yansýmasý için.
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
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
            coinCount = coinCount + 10;
            SetCountText();
            Debug.Log(coinCount);
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
}
