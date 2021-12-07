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

    //【血量控制1/4】
    [Header("最高血量")]
    public int maxHealth = 5;

    [Header("當前血量"), Range(0, 5)]      //在檢查器內的輔助顯示+可調動 
    //private int currentHelth;           //定義當前血量(不顯示)     
    public int currentHealth;             //定義當前血量(顯示在檢查器)


    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //【血量控制2/4】
        currentHealth = maxHealth;
        print("Ruby當前血量為:" + currentHealth);

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
    
     //【血量控制4 / 4】
        if (currentHealth == 0) 
        {
            Application.LoadLevel("Week12_Health-2_damage");

        }
    }
    //【血量控制3/4】
    public void ChangeHealth(int amount)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        print("Ruby 當前血量 :" + currentHealth);
    }


}  

