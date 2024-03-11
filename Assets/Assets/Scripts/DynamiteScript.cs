using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    public int damage;
    public int speed;
    public GameObject explosionPrefab;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //GameObject explosion = Instantiate(explosionPrefab);
            EnemyMovement enemyScript = other.gameObject.GetComponent<EnemyMovement>();
            enemyScript.health -= damage;
            //Destroy(explosion,1f);
            Destroy(gameObject);
        }
        
    }
}
