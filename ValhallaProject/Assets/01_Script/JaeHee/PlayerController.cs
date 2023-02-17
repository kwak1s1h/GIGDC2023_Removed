using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoyStick joyStick;
    [Range(1, 30)][SerializeField] private float dashPower = 1;
    //플레이어 우짜노 ㅋㅋ
    [SerializeField] [Range(0, 1)] private float dashDuration;
    [SerializeField] [Range(0, 1)] private float dashCoolTime;
    private bool canDash = true;

    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Dash()
    {
        if (canDash == false) return;
        canDash = false;
        _rigid.AddForce(joyStick.InputVector * dashPower, ForceMode2D.Impulse);
        StartCoroutine(DashStop());
    }

    private IEnumerator DashStop()
    {
        yield return new WaitForSeconds(dashDuration);
        _rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }
}
