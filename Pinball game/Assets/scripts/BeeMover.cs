using UnityEngine;

public class BeeMover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float leftX = -25f;   // left boundary
    public float rightX = 25f;   // right boundary
    public float speed = 0.2f;   // movement speed

    [Header("Vertical Buzzing")]
    public float buzzAmplitude = 0.5f;
    public float buzzFrequency = 10f; 

    private bool movingRight = true;
    private float baseY;

    void Start()
    {
        baseY = transform.position.y;
    }

    void Update()
    {
        // Horizontal movement
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= rightX)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= leftX)
            {
                movingRight = true;
                Flip();
            }
        }

        float newY = baseY + Mathf.Sin(Time.time * buzzFrequency) * buzzAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
