using UnityEngine;
using System.Collections;

public class ClickToMove4 : MonoBehaviour {

    public float speed = 0.2F;

    private Vector3 wantedPosition;

    void Start()
    {
        wantedPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get wantedPosition on click
        if (Input.GetButtonDown("Fire1"))
        {
            var v3 = Input.mousePosition;
            v3.z = 0;
            wantedPosition = Camera.main.ScreenToWorldPoint(v3);
            wantedPosition.z = 0;
            EchoTest.w.SendString("move:" + wantedPosition);

            Vector3 diff = wantedPosition - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;

            // print("rot_z:" + rot_z);
            // print("transform.rotation.z:" + transform.rotation.z * Mathf.Rad2Deg);
        }

        Vector3 offset = wantedPosition - transform.position;

        if (offset.magnitude > 0.2)
        {
            transform.Translate(offset.normalized * speed, Space.World);
        }

    }

    void Update()
    {
        
        Vector3 direction = wantedPosition - transform.position;

        Quaternion nRotate = Quaternion.LookRotation(direction,Vector3.back); // Vector3.back == (0,0,-1) orientation ??
        // Keep only z-component
        nRotate.x = 0;
        nRotate.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation,nRotate,0.1F);
    }


}

