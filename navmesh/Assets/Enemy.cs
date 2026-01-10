using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 p1, p2;
    public float radius;
    public float speed;
    public Vector3 currentTarget;

    Vector3 moveDirection;

    Transform Player;
    public float viewRadius;
    public float attackRadius;
    public Sprite SkinIdle;
    public Sprite SkinAttack;
    public SpriteRenderer SkinPlayer;
    float Temporizador = 0;
    public Collider2D BoxdeDano;


    public State currentState = State.Idle;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag( "Player" ).transform;
        animator = GetComponent<Animator>();

        initialPosition = transform.position;
        p1 = initialPosition + new Vector3( Random.Range( 0f, radius ), Random.Range( 0f, radius ), 0f );
        p2 = initialPosition + new Vector3( Random.Range( 0f, radius ), Random.Range( 0f, radius ), 0f );

        currentTarget = p1;
        BoxdeDano.enabled = false;
    }

    private void Update()
    {
        
        
    
    }


    void FixedUpdate()
    {

        if ( currentState == State.Idle )
        {
            if ( transform.position != currentTarget )
            {
                transform.position = Vector2.MoveTowards( transform.position, currentTarget, speed * Time.deltaTime );
            }
            else
            {
                print( "chegou ao destino" );
                if ( currentTarget == p1 )
                {
                    currentTarget = p2;
                    p1 = initialPosition + new Vector3( Random.Range( 0f, radius ), Random.Range( 0f, radius ), 0f );
                }
                else
                {
                    currentTarget = p1;
                    p2 = initialPosition + new Vector3( Random.Range( 0f, radius ), Random.Range( 0f, radius ), 0f );
                }
            }


            if ( Vector3.Distance( transform.position, Player.position ) < viewRadius && Player != null)
            {
                OnChasingEnter();
            }


            moveDirection = ( currentTarget - transform.position ).normalized;

        }

        if ( currentState == State.Chasing )
        {
            currentTarget = Player.position;

            if (Vector3.Distance(transform.position, Player.position) > attackRadius)
            {
                transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            }
            else if (Vector3.Distance(transform.position, Player.position) <= 2)
            {
                OnAttackingEnter();
            }
        }

        if (currentState == State.Attacking)
        {
            Temporizador += Time.deltaTime;

            if ( Temporizador > 0.9f)
            {
                OnAttackingExit();
            }
        }

        if (currentState == State.Death) 
        {
            Temporizador += Time.deltaTime;
            if (Temporizador > 1.25f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnChasingEnter()
    {
        currentState = State.Chasing;
        print( "mudei para o estado chasing" );

        Temporizador = 0f;
    }

    void OnAttackingEnter()
    {
        currentState = State.Attacking;
        animator.SetBool("Attacking", true);
        BoxdeDano.enabled = true;
    }

    void OnAttackingExit()
    {
        currentState = State.Idle;
        animator.SetBool("Attacking", false);
        BoxdeDano.enabled = false;

    }

    public void OnDeath()
    {
        currentState = State.Death;
        animator.SetTrigger("dead");
        BoxdeDano.enabled = false;
        Temporizador = 0;
    }

    public enum State
    {
        Idle,
        Chasing,
        Attacking,
        Death
    }
   






}
