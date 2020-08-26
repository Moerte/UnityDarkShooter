using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    public AudioClip shootSound;

    public float effectDisplay = 0.1f;
    public Bullet playerBullet;
    public Transform gunEnd;

    public Rigidbody bombPrefab;
    public Vector2 bombImpulse;
    public Image bombImage;
    public float bombCoolDown = 10f;
    private float bombTimer;

    private float timer;
    private Light gunLight;
    private ParticleSystem gunEffect;
    private AudioPlayer audioPlayer;

    private Level level;

    private void Awake()
    {
        gunLight = GetComponent<Light>();
        gunEffect = GetComponent<ParticleSystem>();
        audioPlayer = GetComponent<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bombTimer = bombCoolDown;
        level = GameManager.instance.levels[GameManager.instance.level];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        bombTimer += Time.deltaTime;
        bombImage.fillAmount = bombTimer / bombCoolDown;
        if (CrossPlatformInputManager.GetButtonDown("Bomb"))
        {
            Bomb();
        }

        if(timer > effectDisplay)
        {
            DisableEffects();
        }
    }

    public void Bomb()
    {
        if(bombTimer >= bombCoolDown)
        {
            bombTimer = 0;
            Rigidbody newBomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
            newBomb.AddForce(transform.forward * bombImpulse.x, ForceMode.Impulse);
            newBomb.AddForce(Vector3.up * bombImpulse.y, ForceMode.Impulse);
        }
    }

    void DisableEffects()
    {
        gunLight.enabled = false;
    }

    public void Shoot()
    {
        if(timer > level.fireRate)
        {
            audioPlayer.PlaySound(shootSound);
            timer = 0;
            Bullet newBullet = Instantiate(playerBullet, gunEnd.position, gunEnd.rotation);
            newBullet.damage = level.damage;
            newBullet.speed = level.bulletSpeed;
            gunLight.enabled = true;
            gunEffect.Stop();
            gunEffect.Play();
        }
    }
}
