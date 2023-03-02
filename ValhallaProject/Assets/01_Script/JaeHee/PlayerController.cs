using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private JoyStick joyStick;
    [Range(1, 30)][SerializeField] private float dashPower = 1;
    //플레이어 우짜노 ㅋㅋ
    [SerializeField][Range(0, 1)] private float dashDuration;
    [SerializeField][Range(0, 1)] private float dashCoolTime;
    private bool canDash = true;

    private Rigidbody2D _rigid;

    [SerializeField] private GameObject attackEffect;
    private GameObject attackTarget = null; //공격 타겟
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

    //곽석현이 일을 안한다니까?
    public void Attack()
    {
        #region 임시
        GameObject obj = Instantiate(attackEffect, transform.position, Quaternion.identity);
        Destroy(obj, 0.2f);
        #endregion
        
        //몬스터 감지하기,가장 가까운 적 탐지
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(5, 5), 0);

        float minDistance = float.MaxValue;

        for (int i = 0; i < cols.Length; i++)
        {
            float distance = Vector2.Distance(cols[i].transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                attackTarget = cols[i].gameObject;
            }
        }
    }
}
