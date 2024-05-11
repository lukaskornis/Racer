using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public Vehicle vehicle;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void LateUpdate()
    {
        text.text = vehicle.rb.velocity.magnitude.ToString("f1") + " m/s";
    }
}