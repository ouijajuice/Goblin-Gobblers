using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isBlocked = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int health;
    public int damage;
    public int pointsOnKill;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {  
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        if (isBlocked == false)
        {
            animator.SetBool("isBlocked", false);
            rb.velocity = Vector2.left * speed;
            //Debug.Log("not blocked");
        }
        else
        {
            animator.SetBool("isBlocked", true);
            rb.velocity = Vector2.zero;
            //Debug.Log("blocked");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool hitTower = collision.gameObject.CompareTag("Tower");
        if (hitTower == true)
        {
            isBlocked = true;
        }
        else
        {
            isBlocked = false;
        }
    }
}
