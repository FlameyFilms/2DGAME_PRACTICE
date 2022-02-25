using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private Transform player;
	public float speed;
	public float stoppingDistance;
	public float retreatingDistance;
	public int health = 100;
	public GameObject deathEffect;
	[SerializeField] public float attackDamage = 10f;
	private float canAttack;
	public GameObject projectile;
	private float timeBtwShots;
	public float startTimeBtwShots;

	void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		timeBtwShots = startTimeBtwShots;
	}


    public void Update()
    {
		if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, 1 * speed * Time.deltaTime);

		}

		if (Vector2.Distance(transform.position, player.position) < retreatingDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);

		}


		if (timeBtwShots <=0 )
        {
			Instantiate(projectile, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
        }
		else
        {
			timeBtwShots -= Time.deltaTime;
        }

	}



    public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			
				collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
			
            }
		
	}

void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}