using UnityEngine;

public class Brains : MonoBehaviour
{
    Vehicle vehicle;
    Path path;
    Vector3 targetPos;
    public float minTurnAngle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();

        transform.position = path.GetClosestPoint(transform.position);
        targetPos = path.GetNextPoint(transform.position);
    }

    void Update()
    {
        Debug.DrawLine(transform.position,targetPos , Color.red);
        float distanceToTarget = Vector3.Distance(transform.position, targetPos);
        if (distanceToTarget< 3)
        {
            targetPos = path.GetNextPoint(transform.position);
        }else if (distanceToTarget < 4)
        {
            vehicle.Brake();

        }

        var angle = Vector3.SignedAngle(transform.forward, targetPos - transform.position, Vector3.up);
        if (Mathf.Abs(angle) > minTurnAngle)
        {
            vehicle.Steer(angle);
        }

        vehicle.Accelerate();
    }
}