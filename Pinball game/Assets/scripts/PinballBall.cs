using UnityEngine;

public class PinballBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D myBody;
    [SerializeField] GameObject hitParticles;
    [SerializeField] AudioClip splatSound;
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource on this object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myBody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            Vector3 hitPos = collision.contacts[0].point;
            Quaternion hitRot = Quaternion.identity;

            GameObject particles = Instantiate(hitParticles, hitPos, hitRot);
            Destroy(particles, 1f);

            // Play splat sound at collision
            if (splatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(splatSound);
            }
        }

        switch (collision.gameObject.tag)
        {
            case "bumper":
                myBody.AddForce(collision.contacts[0].normal * 500);
                break;
            case "flipper":
                myBody.AddForce(collision.contacts[0].normal * 500);
                break;
            default:
                break;
        }
    }
}
