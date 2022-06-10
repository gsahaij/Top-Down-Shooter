using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController
{
    public Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public float GetMouseAngle(Rigidbody2D relativeRigidbody)
    {
        Vector2 aimDirection = GetMousePosition() - relativeRigidbody.position;
        return Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }
}
