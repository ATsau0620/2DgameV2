using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Ruby1123 ruby = collision.GetComponent<Ruby1123>();
        print("�I�쪺�F��O:" + ruby);
        ruby.ChangeHealth(1);
        Destroy(gameObject);

    }
}
