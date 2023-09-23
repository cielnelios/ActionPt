using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private bool isAttack = false;
    private List<GameObject> attackedObjectList = new List<GameObject>();

    public void setAttackReady()
    {
        // 공격할 때만 공격 판정
        attackedObjectList.Clear();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // 몬스터여야 한다.
        if (collider.gameObject.CompareTag("monster"))
        {
            GameObject targetGameobject = collider.gameObject;

            // 스킬 중 다단히트를 막기 위해 히트한 상대 목록을 관리
            if (attackedObjectList.Contains(targetGameobject) == false)
            {
                attackedObjectList.Add(targetGameobject);

                // 상대방의 피격 판정을 불러낸다.
                targetGameobject.TryGetComponent(out Animator targetAnimator);
                targetAnimator.SetTrigger("Damaged");
            }
        }
    }

    public void setAttackExit()
    {
        // 공격 안할 때는 공격 판정 없도록
        attackedObjectList.Clear();
    }
}
