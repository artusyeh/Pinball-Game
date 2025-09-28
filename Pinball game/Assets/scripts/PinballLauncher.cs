using UnityEngine;

public class PinballLauncher : MonoBehaviour
{

    SpringJoint2D mySpring;
    Rigidbody2D myBody;

    [SerializeField]
    float minDist;

    [SerializeField]
    float launchPower;

    [SerializeField]
    PinballBall ballScript;

    void Start()
    {
        mySpring = GetComponent<SpringJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mySpring.distance > minDist)
            {
                mySpring.distance -= 0.01f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myBody.AddForce(transform.up * launchPower);
            mySpring.distance = 2.5f;
        }
    }
}
