using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject powerUpIndicator;
	public float speed = 10f;
	public float powerUpImpulseStrenght = 15f;
	public float powerUpCountdownDuration = 7f;

	private Rigidbody rb;
	private GameObject centerP;
	private bool hasPowerUp = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		centerP = GameObject.Find("CenterPoint");
		powerUpIndicator.gameObject.SetActive(false);
	}

	void Update()
	{
		float forwardInput = Input.GetAxis("Vertical");
		rb.AddForce(centerP.transform.forward * (speed * forwardInput));

		powerUpIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
			hasPowerUp = true;
			Destroy(other.gameObject);
			powerUpIndicator.gameObject.SetActive(true);
			StartCoroutine(PowerUpCountdownRoutine());
		}
	}

	IEnumerator PowerUpCountdownRoutine()
	{
		yield return new WaitForSeconds(powerUpCountdownDuration);
		hasPowerUp = false;
		powerUpIndicator.gameObject.SetActive(false);
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