using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    // Public Fields
    public GameObject rocketPrefab;             // Holds a reference to the rocket
    public Transform firePoint;                 // Where the rocket should be fired from
    public float fireForce = 20f;               // How hard the rocket should be fired
    public Transform centerPoint;               // Where the launcher is pivoting from

    // Private Fields
    private Vector2 differenceInPosition;       // Launcher Position - Pivot Position

    private void Start()
    {
        CenterPointDifference();
    }

    private void Update()
    {
        RotateLauncher();
    }

    /* Calculates the angle between the centerpoint, launcher and mouse to rotate */
    void RotateLauncher()
    {
        // Source: https://answers.unity.com/questions/794119/how-to-rotate-an-object-around-a-fixed-point-so-it.html
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(centerPoint.position);
        Vector2 dir = Input.mousePosition - centerScreenPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = centerPoint.position + q * differenceInPosition;
        transform.rotation = q;
    }
    
    /* Calculates the difference between the launcher and centerpoint for initialization */
    void CenterPointDifference()
    {
        differenceInPosition = (transform.position - centerPoint.position);
    }

    /* Spawns a rocket at the firePoint and adds the force */
    public void Fire()
    {
        // Init the rocket
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        // Give the rocket's rb force using the firePoint's position in Impulse mode
        rocket.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

}
