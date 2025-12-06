using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float CurrentHealth = 3;
    public GameController gc;

    private int qtd_inimigos_mortos;


    void Start()
    {
        CurrentHealth = maxHealth;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        
        if(gameObject.name == "Player")
        {
            gc.setVida(CurrentHealth);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

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
            gameObject.SetActive( false );

        }

    }
}
