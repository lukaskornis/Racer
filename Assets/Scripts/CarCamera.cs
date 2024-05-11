using UnityEngine;

public class CarCamera : MonoBehaviour
{
	public Vehicle target;
	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void LateUpdate()
    {
         transform.position = target.transform.position;
         transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 0.01f);

         cam.fieldOfView = Mathf.Lerp(60, 100, target.speedRatio);
    }
}