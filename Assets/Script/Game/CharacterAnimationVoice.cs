using UnityEngine;
using System.Collections;
using Cinemachine;

public class CharacterAnimationVoice : MonoBehaviour
{
    [Header("ȿ����")]
    [SerializeField] private AudioSource _thisAudioSource;
    [Header("�ٿ� ��� ȸ�� ����")] // ���ĵ� ������ �ǰ��� �ڷ� ������ �ϱ� ����
    [SerializeField] private Transform _thisTransform;
    [SerializeField] private float _angle;  // �ڷ� 90��
    [SerializeField] private float _targetTime; // �Ѿ����µ� �ɸ��� �ð�
    [Header("ī�޶� ����")]
    [SerializeField] private CinemachineImpulseSource _thisCinemachineImpulseSource;
    [Header("����Ʈ")]
    public GameObject myVFX;
    [Header("���� ���� �¿���")]
    [SerializeField] private Punch _punch;


    void Damaged()
    {
        Voice();
        // https://docs.unity3d.com/kr/Packages/com.unity.cinemachine@2.3/manual/CinemachineImpulse.html
        _thisCinemachineImpulseSource.GenerateImpulse();
        Effect();
    }
    void Voice()
    {
        this._thisAudioSource.Play();
    }

    void RotateX()
    {
        StartCoroutine(this.DelayedAction());
    }

    // �ε�
    private float[] _thisTransformEulerAngle = new float[3];
    IEnumerator DelayedAction()
    {
        this._thisTransformEulerAngle[0] = this._thisTransform.eulerAngles.x;
        this._thisTransformEulerAngle[1] = this._thisTransform.eulerAngles.y;
        this._thisTransformEulerAngle[2] = this._thisTransform.eulerAngles.z;

        float _thisTimer = 0f;

        while (_thisTimer < _targetTime)
        {
            _thisTimer += Time.deltaTime;
            float XRotation = Mathf.Lerp(this._thisTransformEulerAngle[0], _angle, _thisTimer / _targetTime) % 360.0f;

            _thisTransform.eulerAngles = new Vector3(XRotation, this._thisTransformEulerAngle[1], this._thisTransformEulerAngle[2]);
             //Debug.Log(_thisTimer + ": " + XRotation + ": " + transform.eulerAngles.x);

            yield return null;
        }
        yield break;
        //yield return null; // ���� �����ӱ��� ���
        //yield return new WaitForSeconds(1.0f); // �Է��� ��(sec) ��ŭ ���
        //yield return new WaitForEndOfFrame(); // ��� ������ �۾��� ���� ������ ���
    }

    void SetRotationNeutral()
    {
        _thisTransform.eulerAngles = new Vector3(
            this._thisTransformEulerAngle[0], 
            this._thisTransformEulerAngle[1], 
            this._thisTransformEulerAngle[2]);
    }

    void Effect()
    {
        Transform _thisTransform = this.gameObject.transform;
        GameObject VFX = Instantiate(myVFX, _thisTransform) as GameObject;
        VFX.transform.SetParent(_thisTransform, true);

        VFX.transform.rotation = Quaternion.Euler(90, 0, 0);
        VFX.transform.localPosition = new Vector3(0, 1, 0);
        VFX.transform.localScale = new Vector3(2, 2, 1);

        Destroy(VFX, 2.0f);
    }

    void AttackStart()
    {
        _punch.gameObject.SetActive(true);
        _punch.setAttackReady();
    }

    void AttackEnd()
    {
        _punch.gameObject.SetActive(false);
        _punch.setAttackExit();
    }
}
