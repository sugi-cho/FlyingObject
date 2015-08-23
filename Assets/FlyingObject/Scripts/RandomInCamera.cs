using UnityEngine;
using System.Collections;

public class RandomInCamera : MonoBehaviour
{
    public Camera viewCam;
    public float interval = 10f;
    public float minDistance = 1f;
    public float maxDistance = 10f;
    // Use this for initialization
    void Start()
    {
        if (viewCam == null)
            viewCam = Camera.main;

        InvokeRepeating("UpdatePosition", 0, interval);
    }

    void UpdatePosition()
    {
        Vector3 pos = Vector3.right * Random.value + Vector3.up * Random.value;
        pos.z = Random.Range(minDistance, maxDistance);
        pos = viewCam.ViewportToWorldPoint(pos);
        transform.position = pos;
    }
}
