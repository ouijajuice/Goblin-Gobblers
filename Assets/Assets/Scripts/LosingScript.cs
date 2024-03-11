using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingScript : MonoBehaviour
{
    public string loseScreen;
    public int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && health <= 0)
        {
            SceneManager.LoadScene(loseScreen);
        }
        if (collision.CompareTag("Enemy"))
        {
            health -= 1;
        }
    }
}
