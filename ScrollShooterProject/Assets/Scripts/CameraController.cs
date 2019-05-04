using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float offsetPercentage = 0.4f;
    void LateUpdate()
    {
        if (target == null)
            return;
        float currentPosition = target.position.x;
        currentPosition = Mathf.Lerp(0, currentPosition, offsetPercentage);

        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
    }
}
