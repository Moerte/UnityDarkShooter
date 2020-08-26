using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : Health
{
    public Slider healthSlider;
    public Image damagemImage;
    public Color damageColor;
    public float flashSpeed = 5;

    public AudioClip damageSound, deathSound;
    public GameObject adButton;

    private bool damaged;
    private Animator anim;
    private PlayerMovement playerMovement;
    private AudioPlayer audioPlayer;
    private bool alreadyDied;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        audioPlayer = GetComponent<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damagemImage.color = damageColor;

        }
        else
        {
            damagemImage.color = Color.Lerp(damagemImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public override void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }
        audioPlayer.PlaySound(damageSound);
        damaged = true;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    protected override void Death()
    {
        isDead = true;
        audioPlayer.PlaySound(deathSound);
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        LevelController.instance.GameOver();

        if (!alreadyDied)
        {
            adButton.SetActive(true);
            //alreadyDied = true;
        }
    }

    protected override void Spawn()
    {
        currentHealth = startingHealth;
    }

    public void Respawn()
    {
        currentHealth = startingHealth;
        anim.Rebind();
        healthSlider.value = currentHealth;
        playerMovement.enabled = true;
        Invoke("SetIsDead", 2.0f);

        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        for(int i = 0; i< enemies.Length; i++)
        {
            enemies[i].Restart();
        }
    }

    void SetIsDead()
    {
        isDead = false;
    }
}
