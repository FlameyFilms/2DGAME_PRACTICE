using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{

	public Transform target;
	public int health = 100;
	public GameObject deathEffect;
	[SerializeField] public float attackDamage = 10f;
	public float speed = 5f;
	public float rotateSpeed = 200f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		Vector2 direction = (Vector2)target.position - rb.position;

		direction.Normalize();

		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = -rotateAmount * rotateSpeed;

		rb.velocity = transform.up * speed;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{

			collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
			Destroy(gameObject);
		}
		if (collision.collider.tag == "Enemy")
		{

			Destroy(gameObject);
		}
		if (collision.collider.tag == "Ground")
		{

			Destroy(gameObject);
		}
	}
}
