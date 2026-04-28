using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera cam;
    private Vector2 min;
    private Vector2 max;
    private float width;
    private float height;

    void Start()
    {
        cam = Camera.main;

        min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // SpriteRenderer sr = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        width = sr.bounds.extents.x;
        height = sr.bounds.extents.y;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x > max.x + width)
            pos.x = min.x - width;
        else if (pos.x < min.x - width)
            pos.x = max.x + width;

        if (pos.y > max.y + height)
            pos.y = min.y - height;
        else if (pos.y < min.y - height)
            pos.y = max.y + height;

        transform.position = pos;
    }
}