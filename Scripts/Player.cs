using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;

    public Transform LeftGun;
    public Transform RightGun;
    public UnityEngine.UI.Text HpText;


    private Transform t;
    [SerializeField]
    private int Health;


    private float TimeGun = 0;

    private void Awake()
    {
        t = transform;
        Damage(0);
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); 
        if(h != 0)
        {
            t.Translate(new Vector3(h, 0, 0) * Time.deltaTime * Speed, Space.World);
            t.localEulerAngles = new Vector3(0, h * 30, 0);
        }
        else
        {
            t.localEulerAngles = new Vector3(0, 0, 0);
        }
        if(Input.GetAxis("Jump") != 0 && TimeGun <= 0)
        {
            Bulet.Fire(LeftGun.position);
            Bulet.Fire(RightGun.position);
            TimeGun = .25f;
        }
        TimeGun -= Time.deltaTime;
    }

    public void Damage(int value)
    {
        Health -= value;
        if (Health == 0)
            Destroy(gameObject);
        if (HpText)
            HpText.text = "HP : " + Health.ToString();
    }
}
