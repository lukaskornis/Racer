using UnityEngine;

public class Brains : MonoBehaviour
{
    Path path;
    Vehicle vehicle;
    public Transform target;
    public float minTurnAngle = 5;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        path = FindObjectOfType<Path>();
        target = path.GetClosestPoint(transform.position);
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 3)
        {
            target = path.GetNextPoint(transform.position);
        }

        Debug.DrawLine(transform.position, target.position,Color.red);
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);

        if (angle > minTurnAngle || angle < - minTurnAngle)
        {
            vehicle.Turn(angle);
        }
        vehicle.Accelerate();
    }
}