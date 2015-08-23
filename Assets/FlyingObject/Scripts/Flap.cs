using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Flying))]
public class Flap : MonoBehaviour
{
    public float gravity = 9.8f;
    public float flapInterval = 1.0f;
    float upVelocity = 0;
    Flying flying;

    void Start()
    {
        flying = GetComponent<Flying>();
        FlapUpdate();
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
        Invoke("FlapUpdate", Random.Range(flapInterval * 0.8f, flapInterval * 1.2f));
    }
}
