using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
	Transform[] points;

	void Awake()
	{
		points = GetComponentsInChildren<Transform>()[1..];
	}

	public Transform GetNextPoint(Vector3 position)
	{
		int index = GetClosestIndex(position);
		index++;
		if(index >= points.Length) index = 0;
		return points[index];
	}


	public int GetClosestIndex(Vector3 position)
	{
		float minDistance = float.MaxValue;
		int minIndex = 0;

		for (int i = 0; i < points.Length;i++)
		{
			float distance = Vector3.Distance(position, points[i].position);
			if (distance < minDistance)
			{
				minDistance = distance;
				 minIndex = i;
			}
		}

		return minIndex;
	}

	public Transform GetClosestPoint(Vector3 position)
	{
		float closestDistance = float.MaxValue;
		Transform closestPoint = null;

		foreach (Transform point in points)
		{
			float distance = Vector3.Distance(position, point.position);
			print( distance );
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestPoint = point;
			}
		}

		return closestPoint;
	}
}