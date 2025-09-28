using UnityEngine;

public class PinballBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D myBody;
    [SerializeField] GameObject hitParticles;
    [SerializeField] AudioClip splatSound;
    private AudioSource audioSource;

    [SerializeField] Transform tp1;
    [SerializeField] Transform tp2;
    [SerializeField] Transform tp3;

    [SerializeField] float teleportCooldown = 0.5f;
    private bool canTeleport = true;

    private PinballManager pinballManager;  //reference to manager

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;

        pinballManager = FindAnyObjectByType<PinballManager>();

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

            if (splatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(splatSound);
            }
        }
        
        DistanceJoint2D joint = collision.gameObject.GetComponent<DistanceJoint2D>();
        if (joint != null)
        {
            joint.enabled = false;
            Debug.Log("Disabled DistanceJoint2D on " + collision.gameObject.name);
        }

        switch (collision.gameObject.tag)
        {
            case "bumper":
                myBody.AddForce(collision.contacts[0].normal * 500);
                break;
            case "flipper":
                myBody.AddForce(collision.contacts[0].normal * 500);
                break;
            case "score":
                if (pinballManager != null)
                {
                    pinballManager.AddScore();
                }
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Tp_2"))
        {
            TeleportBall(tp1.position);
        }
        else if (other.CompareTag("Tp_1"))
        {
            TeleportBall(tp2.position);
        }
        else if (other.CompareTag("Tp_3"))
        {
            TeleportBall(tp2.position);
        }
    }

    private void TeleportBall(Vector3 targetPos)
    {
        Vector2 savedVelocity = myBody.linearVelocity;
        myBody.position = targetPos;
        myBody.linearVelocity = savedVelocity;

        canTeleport = false;
        Invoke(nameof(ResetTeleport), teleportCooldown);
    }

    private void ResetTeleport()
    {
        canTeleport = true;
    }
}
