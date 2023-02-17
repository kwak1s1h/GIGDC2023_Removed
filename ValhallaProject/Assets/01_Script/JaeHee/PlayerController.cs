using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoyStick joyStick;
    [Range(1, 100)][SerializeField] private float dashPower = 1;
    //플레이어 우짜노 ㅋㅋ

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Dash()
    {
        _rigid.AddForce(joyStick.InputVector * dashPower, ForceMode2D.Impulse);
    }
}
