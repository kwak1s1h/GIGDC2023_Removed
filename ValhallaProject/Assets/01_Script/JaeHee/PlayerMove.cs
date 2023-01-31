using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private JoyStick joyStick;

    private Rigidbody2D rigid = null;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(joyStick.Horizontal, joyStick.Vertical);
        //if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
        //{
        //    Move();
        //}
    }

    private void Move()
    {
        //Vector3 hMovement = Vector3.right * speed * Time.fixedDeltaTime * joyStick.Horizontal;
        //Vector3 vMovement = Vector3.up * speed * Time.fixedDeltaTime * joyStick.Vertical;
    }
}
