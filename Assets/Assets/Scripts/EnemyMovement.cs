using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isBlocked = false;
    public float speed;
    public int health;
    public int damage;
    public int pointsOnKill;
    private Rigidbody2D rb;
    private Animator animator;
    public float hitCooldown;
    public Transform overlapTransform;
    public float overlapRadius;
    public LayerMask towerLayer;
    private bool startedDamage = false;

    private void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (health <= 0)
        {
            GameObject pointsManager = GameObject.FindGameObjectWithTag("Points Manager");
            PointsManager pointsScript = pointsManager.GetComponent<PointsManager>();
            pointsScript.points += pointsOnKill;
            Destroy(gameObject);

        }
        Collider2D hitTower = Physics2D.OverlapCircle(new Vector2(overlapTransform.position.x, overlapTransform.position.y), overlapRadius, towerLayer);
        
        if (hitTower)
        {
            TowerScript towerScript = hitTower.GetComponent<TowerScript>();
            animator.SetBool("isBlocked", true);
            rb.velocity = Vector2.zero;
            if (startedDamage == false)
            {
                StartCoroutine(Damaging(hitCooldown, towerScript));
            }
            startedDamage = true;
            isBlocked = true;
            //Debug.Log("blocked");
        }
        else
        {
            startedDamage = false;
            animator.SetBool("isBlocked", false);
            rb.velocity = Vector2.left * speed;
            StopAllCoroutines();
            //Debug.Log("not blocked");
        }
        
    }

   // private void OnTriggerEnter2D(Collider2D collision)
   // {
   //     bool hitTower = collision.gameObject.CompareTag("Tower");
   //     TowerScript towerScript = collision.gameObject.GetComponent<TowerScript>();
   //     if (hitTower == true)
   //     {
   //         isBlocked = true;
   //         StartCoroutine(Damaging(hitCooldown, towerScript));
   //         Debug.Log("starting damage coroutine");
   //     }
   //     if (hitTower == null)
   //     {
   //         isBlocked = false;
   //         StopCoroutine(Damaging(hitCooldown,towerScript));
   //         Debug.Log("stopping damage coroutine");
   //     }
   // }


    private IEnumerator Damaging(float hitCooldown, TowerScript towerScript)
    {
        while (true)
        {
            yield return new WaitForSeconds(hitCooldown);
            towerScript.health -= damage;
        }
        
    }
}
