using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rubyMove = new Vector2();
        rubyMove = transform.position;
        rubyMove.x = rubyMove.x + Input.GetAxis("Horizontal") * moveSpeed;
        transform.position = rubyMove;

        
        Vector2 rubyMove2 = new Vector2();
        rubyMove2 = transform.position;
        rubyMove2.y = rubyMove2.y + Input.GetAxis("Vertical") * moveSpeed;
        transform.position = rubyMove2;
    }
}
