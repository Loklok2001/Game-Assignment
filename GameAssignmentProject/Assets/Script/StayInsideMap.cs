using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInsideMap : MonoBehaviour
{
    public float xWidthP;
    public float yHeightP;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xWidthP, xWidthP),
            Mathf.Clamp(transform.position.y, -yHeightP, yHeightP), 0);
    }
}
