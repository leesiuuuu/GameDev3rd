using UnityEngine;
using DG.Tweening;

public class LogoDown : MonoBehaviour
{
    public RectTransform Pos;

    void Start()
    {
        GetComponent<LogoDown>().enabled = false;
        // DOTween 초기화 (필요한 경우)
        DOTween.Init();

        // 로고 이동 애니메이션 설정
        Pos.DOAnchorPos(new Vector2(0, 933), 1.2f).SetEase(Ease.OutBounce).SetDelay(0.9f);

        // 로고 무한 회전 흔들림 애니메이션 설정
        ShakeRotation(Pos);
    }

    void ShakeRotation(RectTransform rectTransform)
    {
        float duration = 0.8f;  // 단일 회전 지속 시간
        float angle = 3f;      // 회전 각도

        // Sequence 생성
        Sequence sequence = DOTween.Sequence();

        // 양방향 회전 애니메이션 추가
        sequence.Append(rectTransform.DOLocalRotate(new Vector3(0, 0, angle), duration).SetEase(Ease.InOutSine))
                .Append(rectTransform.DOLocalRotate(new Vector3(0, 0, -angle), duration).SetEase(Ease.InOutSine))
                .SetLoops(-1, LoopType.Yoyo);  // 무한 반복 설정
    }
}
