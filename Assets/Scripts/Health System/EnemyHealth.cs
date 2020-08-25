using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : Health
{
    public AudioClip deathSound, damageSound;
    public int scoreValue = 10;
    public float sinkSpeed = 2.5f;
    private bool isSinking;
    private ParticleSystem hitParticles;
    private Animator anim;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private NavMeshAgent navMeshAgent;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        Spawn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSinking)
        {
            transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }

    public override void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead)
            return;
        audioPlayer.PlaySound(damageSound);
        currentHealth -= damage;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    protected override void Death()
    {
        isDead = true;
        audioPlayer.PlaySound(deathSound);
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Death");
        LevelController.instance.UpdateScore(scoreValue);
        
    }

    public void StartSinking()
    {
        navMeshAgent.enabled = false;
        rb.isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2);
    }

    protected override void Spawn()
    {
        currentHealth = startingHealth;
    }
}
