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

    private bool damaged;
    private Animator anim;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
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
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        LevelController.instance.GameOver();
    }

    protected override void Spawn()
    {
        currentHealth = startingHealth;
    }
}
