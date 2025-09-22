using UnityEngine;

public class PinballBall : MonoBehaviour
{
    //serialize field gives lets me set the variable in the inspector
    //without having to make that variable public
    [SerializeField]
    Rigidbody2D myBody; //var ref to this game object's rigidbody

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //set the ball's body to dynamic (allow physics forces to act on it)
            myBody.bodyType = RigidbodyType2D.Dynamic;
            //myBody.linearVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        //check the tag of the game object we collided with
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
