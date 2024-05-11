using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vehicle vehicle;
    public float smoothness;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        cam.fieldOfView = Mathf.Lerp(60, 90, vehicle.speedRatio);

        transform.position = vehicle.transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, vehicle.transform.rotation,smoothness * Time.deltaTime);
    }
}