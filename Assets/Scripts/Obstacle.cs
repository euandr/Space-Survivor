using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject bounceEffectPrefab;
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    Rigidbody2D rb;
    public float minSpeed = 50f;
    public float maxSpeed = 150f;
    public float maxSpinSpeed = 10f;
    
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
        
        float randomSize = Random.Range(minSize,maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);   
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize; 
        Vector2 randomDirection = Random.insideUnitCircle;

        rb.AddForce(randomDirection* randomSpeed);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point; 
        GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

        // Destroy the effect after 1 second
        Destroy(bounceEffect, 0.5f);
    }
}
