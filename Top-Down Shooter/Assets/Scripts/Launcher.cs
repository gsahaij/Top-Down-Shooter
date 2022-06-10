using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    


    public Transform centerPoint;
    private Vector2 v;


    MouseController ms = new MouseController();

    private void Start()
    {
        v = (transform.position - centerPoint.position);
    }

    private void Update()
    {
        // Source: https://answers.unity.com/questions/794119/how-to-rotate-an-object-around-a-fixed-point-so-it.html
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(centerPoint.position);
        Vector2 dir = Input.mousePosition - centerScreenPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = centerPoint.position + q * v;
        transform.rotation = q;
        //firePoint.rotation = q;
        



        //rb.rotation = ms.GetMouseAngle(rb);
    }
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

}
