using UnityEngine;

public class BreakableJoint : MonoBehaviour
{
    private DistanceJoint2D joint;
    private bool isBreaking = false;

    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        if (joint != null && !joint.enabled && !isBreaking)
        {
            isBreaking = true;
            //Destroy this object after 3 seconds
            Destroy(gameObject, 3f);
        }
    }
}
