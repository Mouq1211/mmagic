using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage( float damage )
    {
        print( "Causando dano" );
        if ( currentHealth - damage > 0 )
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0;
            print( $"Eu, {gameObject.name}, morri" );
            Destroy( gameObject );

        }

    }
}
