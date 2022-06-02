using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Follow();
    }

    // Update is called once per frame
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothCam = Vector3.Lerp(targetPosition, transform.position, smoothFactor * Time.deltaTime);
        transform.position = targetPosition;
    }
}
