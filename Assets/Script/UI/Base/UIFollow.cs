using UnityEngine;

public class UIFollow : UIBase
{
    protected Transform followAt;
    protected Vector3 velocity;

    protected virtual void LateUpdate()
    {
        if (!followAt)
            return;

        UpdatePosition(true);
    }

    protected void UpdatePosition(bool isSmoot = false)
    {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(followAt.position);
        if (isSmoot)
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.01f);
        else
            transform.position = targetPosition;
    }
}