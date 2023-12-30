using UnityEngine;



public class EnemyAi : MonoBehaviour

{

    public float speed;

    public float lineOfSight;

    public float shootingRange;

    public float fireRate;

    private float nextFireTime;

    public GameObject bullet;

    public GameObject bulletParent;

    private Transform player;



    void Start()

    {

        player = GameObject.FindGameObjectWithTag("Player").transform; // FIND THE PLAYER

    }



    void Update()

    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position); // When player goes near enemy



        // Will move when player in line of sight, but not move when in shooting range

        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)

        {

            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

        }

        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)

        {

            GameObject bulletShoot =  Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            bulletShoot.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * speed;
            nextFireTime = Time.time + fireRate;

        }



    }



    private void OnDrawGizmosSelected()

    {

        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, lineOfSight);

        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

}