using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BaseItem : MonoBehaviour
{
    public bool isPickingUp;
    public string objectId;
    private QuadraticCurve _curve;
    private Action _onFinished;
    private CircleCollider2D _collider2D;
    private float _time;
    private float _speed;

    void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
        _collider2D.isTrigger = true;
        gameObject.layer = GameLayer.Item;
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