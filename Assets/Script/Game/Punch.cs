using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private bool isAttack = false;
    private List<GameObject> attackedObjectList = new List<GameObject>();

    public void setAttackReady()
    {
        // 공격할 때만 공격 판정
        isAttack = true;
        attackedObjectList.Clear();
        Debug.Log("Attack 1");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("checked");
        //// 몬스터여야 한다.
        //if (collision.collider.gameObject.CompareTag("monster") && isAttack ==  true)
        //{
        //    Debug.Log("monster");
        //    GameObject targetGameobject = collision.gameObject;

        //    // 스킬 중 다단히트를 막기 위해 히트한 상대 목록을 관리
        //    if ( attackedObjectList.Contains(targetGameobject) == false )
        //    {
        //        attackedObjectList.Add(targetGameobject);
        //        Debug.Log("added");

        //        // 상대방의 피격 판정을 불러낸다.
        //        if (TryGetComponent(out Animator targetAnimator))
        //        {
        //            targetAnimator.SetTrigger("Damaged");

        //            Debug.Log("Attack Success");
        //        }
        //    }
        //}
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌 중!");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 끝!");
    }

    public void setAttackExit()
    {
        // 공격 안할 때는 공격 판정 없도록
        isAttack = false;
        attackedObjectList.Clear();
        Debug.Log("Attack 2");
    }
}
