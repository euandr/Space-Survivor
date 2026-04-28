using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

     public GameObject OpenMenuButton;
    public GameObject AudioBaground;
    public GameObject AudiogameOver;
    public InputAction moveForward;
    public InputAction lookPosition;
    
    public GameObject borderParent;

    private Button restartButton;
    public GameObject explosionEffect;
    private Label highScore;
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
        OpenMenuButton.SetActive(false);
        
        AudioBaground.SetActive(true);
        AudiogameOver.SetActive(false);

        moveForward.Enable();
        lookPosition.Enable();

        highScore = uiDocument.rootVisualElement.Q<Label>("highScore");
        highScore.style.display = DisplayStyle.None;  
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;

        int highScor = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = "High Score: " + highScor;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();
      
    }

    void OnCollisionEnter2D()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;

        int highScor = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScor)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            PlayerPrefs.Save();
        }
        highScore.style.display = DisplayStyle.Flex;
        borderParent.SetActive(false);
        AudioBaground.SetActive(false);
        AudiogameOver.SetActive(true);
        OpenMenuButton.SetActive(true);
        

        Destroy(gameObject);
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        // Debug.Log($"score: {score}");
        scoreText.text ="Score: " + score;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        

    }

    void MovePlayer()
    {
        if (moveForward.IsPressed())
        {
            boosterFlame.SetActive(true);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(lookPosition.ReadValue<Vector2>());
            // Debug.Log($"Position of Mouse: , {mousePos}");

            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
               rb.linearVelocity  = rb.linearVelocity.normalized * maxSpeed;
            }
            
        }
        else if(moveForward.WasReleasedThisFrame())
        {
            boosterFlame.SetActive(false);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
