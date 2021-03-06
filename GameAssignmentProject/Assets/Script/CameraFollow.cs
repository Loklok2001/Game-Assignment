using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;
    //public Vector3 offset;
    //public float smoothFactor;

    //private void FixedUpdate()
    //{
    //    Follow();
    //}

    //void Follow()
    //{
    //    Vector3 targetPosition = target.position + offset;
    //    Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
    //    transform.position = target.position + offset;
    //}

    public Transform player;
    public float xWidthC;
    public float yHeightC;

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -xWidthC, xWidthC),
            Mathf.Clamp(player.position.y, -yHeightC, yHeightC), transform.position.z);
    }
}
