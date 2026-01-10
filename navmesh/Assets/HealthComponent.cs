using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float CurrentHealth = 3;
    public GameController gc;

    private int qtd_inimigos_mortos;

    public bool isPlayer;

    void Start()
    {
        CurrentHealth = maxHealth;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            gc.setVida(CurrentHealth);
        }
    }
    public void TakeDamage( float damage )
    {
        if (gameObject.name == "Player")
        {
            gc.setVida(CurrentHealth);
        }
        
        if ( CurrentHealth - damage > 0 )
        {
            CurrentHealth -= damage;
        }
        else
        {
            if(gameObject.tag == "Enemy")
            {
                gc.setKills();
            }
            CurrentHealth = 0;
            print( $"Eu, {gameObject.name}, morri" );

            if (isPlayer)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("game");
            }
            else 
            {
                Enemy enemy = gameObject.GetComponent<Enemy>();
                enemy.OnDeath();
            }


        }

    }
}
