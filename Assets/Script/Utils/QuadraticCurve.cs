using System;
using UnityEngine;

[Serializable]
public class QuadraticCurve
{
    public Vector3 posStart;
    public Vector3 posEnd;
    public Vector3 posCenter;
    public QuadraticCurve() { }
    public QuadraticCurve(Vector3 posStart, Vector3 posEnd, Vector3 posCenter)
    {
        this.posStart = posStart;
        this.posEnd = posEnd;
        this.posCenter = posCenter;
    }

    public Vector3 Evaluate(float t)
    {
        Vector3 sc = Vector3.Lerp(posStart, posCenter, t);
        Vector3 ce = Vector3.Lerp(posCenter, posEnd, t);
        return Vector3.Lerp(sc, ce, t);
    }

    public void DrawPath()
    {
        if (posStart == null || posEnd == null || posCenter == null)
        {
            return;
        }

        Vector3 previousDrawPoint = posStart;

        for (int i = 0; i <= 20; i++)
        {
            Vector3 drawPoint = Evaluate(i / 20f);
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }
}