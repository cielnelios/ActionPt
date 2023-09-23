using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private bool isAttack = false;
    private List<GameObject> attackedObjectList = new List<GameObject>();

    public void setAttackReady()
    {
        // ������ ���� ���� ����
        attackedObjectList.Clear();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // ���Ϳ��� �Ѵ�.
        if (collider.gameObject.CompareTag("monster"))
        {
            GameObject targetGameobject = collider.gameObject;

            // ��ų �� �ٴ���Ʈ�� ���� ���� ��Ʈ�� ��� ����� ����
            if (attackedObjectList.Contains(targetGameobject) == false)
            {
                attackedObjectList.Add(targetGameobject);

                // ������ �ǰ� ������ �ҷ�����.
                targetGameobject.TryGetComponent(out Animator targetAnimator);
                targetAnimator.SetTrigger("Damaged");
            }
        }
    }

    public void setAttackExit()
    {
        // ���� ���� ���� ���� ���� ������
        attackedObjectList.Clear();
    }
}
