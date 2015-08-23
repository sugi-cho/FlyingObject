using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour
{

    public TargetObject target;
    public float speed = 1.0f;
    public float maxDeltaRotate = 45f;
    public bool ignoreY;

    // Use this for initialization
    void Start()
    {
        if (target == null)
            target = FindObjectOfType<TargetObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;
        Vector3 position = transform.position;
        if (ignoreY)
            targetPos.y = position.y;
        Vector3 to = targetPos - position;
        Quaternion toRot = Quaternion.LookRotation(to, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, maxDeltaRotate * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        if (target != null)
            Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * speed);
    }
}
