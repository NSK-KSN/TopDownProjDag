using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public int damage;
    private Player player;
    private ScoreManager sm;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        sm = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            sm.Kill();
            Destroy(gameObject);
        }
        if(player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    //Для анимации атаки, мб надо будет
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {  
            if (timeBtwAttack <= 0)
            {
                player.health -= damage;
                timeBtwAttack = startTimeBtwAttack;
                //anim.SetTrigger("attack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    } 
}
