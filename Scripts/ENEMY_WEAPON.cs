using System.Collections;
using System.Threading;
using UnityEngine;

public class ENEMY_WEAPON : MonoBehaviour

{
    [SerializeField] public float attackDamage = 10f;
    public float speed;
    private Transform player;
    private Vector2 Target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            
            DestroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);


            DestroyProjectile();
        }
        if (other.CompareTag("Ground"))
        {



            DestroyProjectile();
        }
    }



    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}