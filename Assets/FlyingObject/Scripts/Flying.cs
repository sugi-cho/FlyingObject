using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour
{

    public TargetObject target;
    public float speed = 1.0f;
    public float maxDeltaRotate = 45f;

    // Use this for initialization
    void Start()
    {
        if (target == null)
            target = FindObjectOfType<TargetObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 to = target.position - transform.position;
        Quaternion toRot = Quaternion.LookRotation(to, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, maxDeltaRotate * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
