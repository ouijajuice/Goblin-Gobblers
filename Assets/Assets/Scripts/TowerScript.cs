using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    private Animator animator;
    public bool killed = false;
    public float fireCooldownDuration;
    private float fireCooldown = 3f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float range;
    private void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void Update()
    {
        if(health <= 0)
        {
            //animator.SetBool("Dying", true);
            killed = true;
            Destroy(this.gameObject, 1f);
        }
        //add range to this eventually
        if (fireCooldown <= 0f )                
        {
            animator.SetBool("Firing", true);
            GameObject projectile = Instantiate(projectilePrefab,firePoint);
            fireCooldown = fireCooldownDuration;
        }
        else
        {
            animator.SetBool("Firing", false);
            fireCooldown -= Time.deltaTime;
        }
    }

}
