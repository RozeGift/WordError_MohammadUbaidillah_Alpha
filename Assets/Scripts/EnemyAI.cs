using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemyai;
    public Transform player;

    int maxdist = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyai.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) <= maxdist)
        {
            enemyai.isStopped = true;
            //attack anim
        }
        else if (Vector3.Distance(transform.position, player.position) >= maxdist)
        {
            enemyai.isStopped = false;
            enemyai.SetDestination(player.position);
            //walk anim
        }


    }
}
