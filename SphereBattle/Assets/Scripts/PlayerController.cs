using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public float powerUpImpulseStrenght = 15f;

	private Rigidbody rb;
	private GameObject centerP;
	private bool hasPowerUp = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		centerP = GameObject.Find("CenterPoint");
	}

	void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		rb.AddForce(centerP.transform.forward * (speed * forwardInput));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			hasPowerUp = true;
			Destroy(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
		{
			Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
			
			enemyRb.AddForce(awayFromPlayer * powerUpImpulseStrenght, ForceMode.Impulse);
			Debug.Log($"Collided with {other.gameObject.name} with hasPowerUp set to {hasPowerUp}");
		}
	}
}