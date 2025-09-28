using UnityEngine;

public class PinballFlipper : MonoBehaviour
{
    [SerializeField] KeyCode flipKey;
    [SerializeField] Rigidbody2D myBody;
    [SerializeField] float flipPower = 800f;
    [SerializeField] bool invertDirection = false; //toggle for left flipper

    void Update()
    {
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        JointMotor2D motor = hinge.motor;

        float direction;

        if (invertDirection)
        {
            direction = -1f;
        }
        else
        {
            direction = 1f;
        }


        if (Input.GetKey(flipKey))
            motor.motorSpeed = direction * flipPower;   //flip up
        else
            motor.motorSpeed = direction * -flipPower * 0.6f;

        hinge.motor = motor;
    }
}
