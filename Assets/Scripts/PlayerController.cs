using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;



public class PlayerController : MonoBehaviour
{
    private Label scoreText;
    public UIDocument uiDocument;
    private float score = 0f;
    public float scoreMultiplier =10f;
    private float elapsedTime = 0f;
    public GameObject boosterFlame;
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        // Debug.Log($"score: {score}");
        scoreText.text ="Score: " + score;

    }

    void MovePlayer()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            boosterFlame.SetActive(true);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            // Debug.Log($"Position of Mouse: , {mousePos}");

            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
               rb.linearVelocity  = rb.linearVelocity.normalized * maxSpeed;
            }
            
        }
        else if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            boosterFlame.SetActive(false);
        }
    }
}
