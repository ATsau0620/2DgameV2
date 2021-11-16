using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{

    public float moveSpeed=0.5f;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rubyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyMove = new Vector2();
        rubyMove = transform.position;
        rubyMove.x = rubyMove.x + Input.GetAxis("Horizontal") * moveSpeed;
        rubyMove.y = rubyMove.y + Input.GetAxis("Vertical") * moveSpeed;
        rb.MovePosition(rubyMove);
     }
} 
