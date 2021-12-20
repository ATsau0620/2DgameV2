using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby1123 : MonoBehaviour
{
    private Vector2 lookDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float speed = 3;

    //�i��q����1/4�j
    [Header("�̰���q")]
    public int maxHealth = 5;

    [Header("��e��q"), Range(0, 5)]      //�b�ˬd���������U���+�i�հ� 
    //private int currentHelth;           //�w�q��e��q(�����)     
    public int currentHealth;             //�w�q��e��q(��ܦb�ˬd��)

    //�i�o�g�l�u 1 �j
    public GameObject projectilePrefab;

   private AudioSource audioSource;

    public AudioClip playerHit;

    public AudioClip ThrowCog;


    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //�i��q����2/4�j
        currentHealth = maxHealth;
        print("Ruby��e��q��:" + currentHealth);


        audioSource = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {

        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //print("Horizontal is: " + horizontal);
        //print("Vertical is: " + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookDirection = rubyMove;
            lookDirection.Normalize();

        }

        rubyAnimator.SetFloat("Look X", lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);

        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);

        //�i��q����4 / 4�j
        if (currentHealth == 0)
        {
            Application.LoadLevel("Week12_Health-2_damage");

        }

        //�i�o�g�l�u 3/3�j
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
            PlaySound(ThrowCog);
        }
    }
    //�i��q����3/4�j
    public void ChangeHealth(int amount)
    {
     if (amount <0)
        {
            PlaySound(playerHit);
        }

        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        print("Ruby ��e��q :" + currentHealth);

       
    }

    //�i�o�g�l�u 2/3�j
    private void Launch()
    {

        GameObject projectileObject = Instantiate(projectilePrefab,
               rb.position, Quaternion.identity);


        Bullet bullet = projectileObject.GetComponent<Bullet>();

        bullet.Launch(lookDirection, 300);

        rubyAnimator.SetTrigger("Launch");
    }

    
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}  

