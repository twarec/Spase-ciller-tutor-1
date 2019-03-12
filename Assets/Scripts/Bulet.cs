using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour {
    private static string ResPath = "Bulet";
    public static Bulet bulet;
    public static void Fire(Vector3 pos)
    {
        if (bulet == null)
            bulet = Resources.Load<Bulet>(ResPath);
        Instantiate<Bulet>(bulet, pos, Quaternion.identity);
    }

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
        t.Translate(Vector3.up * Time.deltaTime * Speed, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enum"))
        {
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);
        }
    }
}
