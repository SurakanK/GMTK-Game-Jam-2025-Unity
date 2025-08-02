using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BaseItem : MonoBehaviour
{
    public SpriteRenderer imageItem;
    private QuadraticCurve _curve;
    private Action _onFinished;
    private float _time;
    private float _speed;
    public ItemData itemData;

    public void Initialized(ItemData item)
    {
        itemData = item;
        if (imageItem)
            imageItem.sprite = item.icon;
    }

    public void Launch(QuadraticCurve curve, float speed)
    {
        _speed = speed;
        _curve = curve;
    }

    public void Launch(QuadraticCurve curve, float speed, Action OnFinished)
    {
        _speed = speed;
        _curve = curve;
        _onFinished = OnFinished;
    }

    void OnDisable()
    {
        _time = 0;
        _onFinished = null;
    }

    void Update()
    {
        if (_curve != null)
        {
            _time += Time.deltaTime * _speed;
            transform.position = _curve.Evaluate(_time);

            if (_time >= 1f)
            {
                _onFinished?.Invoke();
                _onFinished = null;
                _curve = null;
                _time = 0;
            }
        }

        if (_curve != null)
        {
            _curve.DrawPath();
        }
    }
}