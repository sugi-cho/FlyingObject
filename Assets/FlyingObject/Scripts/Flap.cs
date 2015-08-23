using UnityEngine;
using System.Collections;

public class Flap : MonoBehaviour
{
    public float gravity = 9.8f;
    public float flapInterval = 1.0f;
    float upVelocity = 0;
    Flying flying;

    void Start()
    {
        Invoke("ShowUpVel", 1f);
        InvokeRepeating("FlapUpdate", 0, flapInterval);
        flying = GetComponent<Flying>();
    }
    void ShowUpVel()
    {
        Debug.Log(upVelocity);
    }
    void Update()
    {
        upVelocity -= gravity * Time.deltaTime;
        transform.position += Vector3.up * upVelocity;
    }
    void FlapUpdate()
    {
        upVelocity += -upVelocity + 0.5f * gravity * flapInterval
        * (transform.position.y < flying.target.position.y ? 1.5f : 0.5f);
    }
}
