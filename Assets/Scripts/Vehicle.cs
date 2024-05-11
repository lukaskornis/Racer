using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public float maxSpeed = 10;
	public float acceleration = 1.0f;
	public float rotateSpeed = 1.0f;
	public float brakeAcceleration = 3;
	public float reverseAcceleration = 1;
	public AnimationCurve pitchCurve;
	public AnimationCurve rotateSpeedCurve;
	Rigidbody rb;
	AudioSource engineSound;
	public float speedRatio;
	public float sideDrag = 1;
	public float drag = 0.1f;
	public bool isAccelerating;
	Vector3 localVelocity;
	public ParticleSystem brakeParticles;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		engineSound = GetComponent<AudioSource>();
		rb.maxLinearVelocity = maxSpeed;
	}

	void Update()
	{
		//print( (int)(rb.velocity.magnitude) + " m/s");
		speedRatio = rb.velocity.magnitude / maxSpeed;
		engineSound.pitch = pitchCurve.Evaluate(speedRatio);

		localVelocity = transform.InverseTransformVector(rb.velocity);

		// DRAG
		rb.velocity += -transform.right * localVelocity.x * sideDrag * Time.deltaTime;

		if (!isAccelerating)
		{
			rb.velocity += -transform.forward * localVelocity.z * drag * Time.deltaTime;
		}


		if (Mathf.Abs(localVelocity.normalized.x) > 0.1f)
		{


		}
		else
		{
	
		}

		isAccelerating = false;
		brakeParticles.Stop();
	}

	public void Steer(float value)
	{
		value = Mathf.Clamp(value, -1, 1);
		transform.Rotate(0, value * rotateSpeed *  rotateSpeedCurve.Evaluate(speedRatio) * Mathf.Sign(localVelocity.z) * Time.deltaTime, 0);
	}

	public void Accelerate()
	{
		rb.velocity += transform.forward * acceleration * Time.deltaTime;
		isAccelerating = true;
	}

	public void Brake()
	{
		var acc = speedRatio > 0f ? brakeAcceleration : reverseAcceleration;
		rb.velocity += -transform.forward * acc * Time.deltaTime;
	}
}