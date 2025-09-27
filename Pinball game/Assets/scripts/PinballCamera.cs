using UnityEngine;

public class PinballCamera : MonoBehaviour
{

    [SerializeField]
    Transform ballTransform;
    [SerializeField]
    float smoothVal;
    Vector3 velocity = Vector3.zero;

    Vector3 startPos;

    void Start()
    {
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = ballTransform.position;
        //target.x = startPos.x;
        target.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        //transform.rotation = Quaternion.identity;
    }
}