using UnityEngine;
using UnityEngine.Events;

public class BulletProjectile : Bullet
{
    [Header("Debug")]
    [SerializeField] private bool _isDrawn;

    [Header("Setting")]
    [SerializeField] private float speed;
    [SerializeField] private bool _isRotate;
    [SerializeField] private Vector3 _offset;

    public UnityAction OnProjectileFinished { get; set; }
    private CircleCollider2D _collider2D;
    private QuadraticCurve _curve;
    private float _time;
    private bool _isHit;

    void Awake()
    {
        _collider2D = GetComponent<CircleCollider2D>();
    }

    void OnEnable()
    {
        _collider2D.enabled = true;
        _isHit = false;
    }

    void Update()
    {
        if (_curve != null)
        {
            _time += Time.deltaTime * speed;
            transform.position = _curve.Evaluate(_time);

            Vector3 dir3D = _curve.Evaluate(_time + 0.001f) - transform.position;
            if (dir3D.sqrMagnitude > 0f && _isRotate)
            {
                Vector2 dir2D = new Vector2(dir3D.x, dir3D.y).normalized;
                float angle = Mathf.Atan2(dir2D.y, dir2D.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }

            if (_time >= 1f && !_isHit)
            {
                _curve = null;
                _collider2D.enabled = false;
                OnProjectileFinished?.Invoke();
            }
        }

        if (_isDrawn && _curve != null)
        {
            _curve.DrawPath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Owner == null)
            return;
        _collider2D.enabled = false;
        _isHit = true;
        ApplyDamage(null);
        OnDestroy?.Invoke();
    }

    public override void Launch(Vector3 position, BaseWeapon weapon)
    {
        base.Launch(position, weapon);
        Vector3 targetPosition = GameUtils.RandomAroundPosition2D(position, 0.2f) + _offset;
        Vector3 startPosition = transform.position;
        _curve = new QuadraticCurve(startPosition, targetPosition, GetCenterPosition(targetPosition));
        _time = 0;
    }

    private Vector3 GetCenterPosition(Vector3 positionTarget)
    {
        Vector3 startPos = transform.position;
        Vector3 center = (startPos + positionTarget) * 0.5f;

        float distance = Vector3.Distance(startPos, positionTarget);
        float heightFactor = Random.Range(0.1f, 0.2f);
        float apexHeight = distance * heightFactor;

        center.y += apexHeight;
        return center;
    }
}