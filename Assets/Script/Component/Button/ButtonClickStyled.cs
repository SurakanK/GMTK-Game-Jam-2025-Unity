using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Button), typeof(CanvasGroup))]
public class ButtonClickStyled : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector3 _pressedScale = new Vector3(1.2f, 1.2f, 1f);
    [SerializeField] private float _duration = 0.1f;

    private Transform _target;
    private Vector3 _originalScale;

    private void Awake()
    {
        _target = transform;
        _originalScale = _target.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _target.DOKill();
        _target.DOScale(_pressedScale, _duration).SetEase(Ease.OutExpo);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _target.DOKill();
        _target.DOScale(_originalScale, _duration).SetEase(Ease.OutExpo);
    }
}
