using UnityEngine;

public class CreditsRoll : MonoBehaviour
{
    public GameObject botaoVoltar;
    public float speed = 2f;
    public float limiteY = 500f;

    void Start()
    {
        botaoVoltar.SetActive(false);
    }
    void Update()
    {
        if (transform.position.y < limiteY)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }else
        {
            botaoVoltar.SetActive(true);
        }
    }
}

