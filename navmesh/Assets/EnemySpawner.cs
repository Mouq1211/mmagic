using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawns;
    public float timer;
    public GameObject Enemy;


    private void Update()
    {
        timer += Time.deltaTime;
        print(timer);
        if (timer >= 5) 
        {
            timer = 0;
            spawn_enemy();
        }
    }



    public void spawn_enemy()
    {

        Instantiate(Enemy, spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
    
    }



}
