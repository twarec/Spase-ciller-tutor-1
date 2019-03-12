using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour {

    public float Speed;
    public float DestroyTime;

    private Transform t;


    private void Awake()
    {
        t = transform;
        Destroy(gameObject, DestroyTime);
    }

    private void Update()
    {
        t.Translate(Vector3.up * -Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Damage(1);
            Destroy(gameObject);
        }
    }
}
