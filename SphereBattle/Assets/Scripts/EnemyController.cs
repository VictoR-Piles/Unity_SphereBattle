using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed = 10f;

	private Rigidbody rb;
	private GameObject player;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
	}

	void Update()
	{
		Vector3 direction = (player.transform.position - transform.position).normalized;
		rb.AddForce(direction * speed);

		if (transform.position.y < -10)
		{
			Destroy(gameObject);
		}
	}
}