using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    private bool isAttack = false;
    private List<GameObject> attackedObjectList = new List<GameObject>();

    public void setAttackReady()
    {
        // ������ ���� ���� ����
        isAttack = true;
        attackedObjectList.Clear();
        Debug.Log("Attack 1");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("checked");
        //// ���Ϳ��� �Ѵ�.
        //if (collision.collider.gameObject.CompareTag("monster") && isAttack ==  true)
        //{
        //    Debug.Log("monster");
        //    GameObject targetGameobject = collision.gameObject;

        //    // ��ų �� �ٴ���Ʈ�� ���� ���� ��Ʈ�� ��� ����� ����
        //    if ( attackedObjectList.Contains(targetGameobject) == false )
        //    {
        //        attackedObjectList.Add(targetGameobject);
        //        Debug.Log("added");

        //        // ������ �ǰ� ������ �ҷ�����.
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
        Debug.Log("�浹 ��!");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("�浹 ��!");
    }

    public void setAttackExit()
    {
        // ���� ���� ���� ���� ���� ������
        isAttack = false;
        attackedObjectList.Clear();
        Debug.Log("Attack 2");
    }
}
