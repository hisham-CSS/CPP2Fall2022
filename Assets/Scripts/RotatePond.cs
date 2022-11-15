using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePond : MonoBehaviour
{
    public float rotationSpeed = 300;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
