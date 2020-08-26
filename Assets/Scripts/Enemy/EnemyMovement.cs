using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform player;
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private Animator anim;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            nav.SetDestination(player.position);
        else
        {
            anim.SetBool("PlayerDeath", true);
            nav.enabled = false;
        }
    }

    public void Restart()
    {
        nav.enabled = true;
        anim.SetBool("PlayerDeath", false);
    }
}
