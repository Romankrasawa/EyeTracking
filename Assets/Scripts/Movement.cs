using UnityEngine;

public class Movement : MonoBehaviour
{
    public float A = 2f;
    public float speed = 1f;

    private float t = 0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        t += Time.deltaTime * speed;

        float denom = 1 + Mathf.Sin(t) * Mathf.Sin(t);
        float x = A * Mathf.Cos(t) / denom;
        float y = A * Mathf.Cos(t) * Mathf.Sin(t) / denom;

        transform.position = startPos + new Vector3(x, y, 0);
    }
}
