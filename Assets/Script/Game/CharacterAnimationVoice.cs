using UnityEngine;
using System.Collections;
using Cinemachine;

public class CharacterAnimationVoice : MonoBehaviour
{
    [Header("효과음")]
    [SerializeField] private AudioSource _thisAudioSource;
    [Header("다운 모션 회전 보정")] // 스탠딩 상태의 피격을 뒤로 눕혀야 하기 때문
    [SerializeField] private Transform _thisTransform;
    [SerializeField] private float _angle;  // 뒤로 90도
    [SerializeField] private float _targetTime; // 넘어지는데 걸리는 시간
    [Header("카메라 진동")]
    [SerializeField] private CinemachineImpulseSource _thisCinemachineImpulseSource;
    [Header("이펙트")]
    public GameObject myVFX;
    [Header("공격 판정 온오프")]
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

    // 로딩
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
        //yield return null; // 다음 프레임까지 대기
        //yield return new WaitForSeconds(1.0f); // 입력한 초(sec) 만큼 대기
        //yield return new WaitForEndOfFrame(); // 모든 랜더링 작업이 끝날 때까지 대기
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
