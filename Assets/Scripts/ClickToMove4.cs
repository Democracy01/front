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

            print("rot_z:" + rot_z);
            print("transform.rotation.z:" + transform.rotation.z * Mathf.Rad2Deg);
        }

        Vector3 offset = wantedPosition - transform.position;

        if (offset.magnitude > 0.2)
        {
            transform.Translate(offset.normalized * speed, Space.World);
        }

    }

    void Update()
    {
        float angle = Vector3.Angle(wantedPosition, transform.position);
       
        //print("angle" + angle);
        // Make it face the right direction
        Vector3 diff = wantedPosition - transform.position;
        diff.Normalize();

        float rot_z = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg + 270) % 360;

        
        //print();
        if (rot_z > transform.localEulerAngles.z + 1)
        {
            print("rot_z:" + rot_z + " > transform.rotation.z:" + transform.localEulerAngles.z);
            transform.Rotate(new Vector3(0, 0, Mathf.Min(250F * Time.deltaTime, rot_z - transform.localEulerAngles.z)));
        }
        else if (rot_z < transform.localEulerAngles.z - 1)
        {
            print("rot_z:" + rot_z + " < transform.rotation.z:" + transform.localEulerAngles.z);
            transform.Rotate(new Vector3(0, 0, Mathf.Max(-250F * Time.deltaTime, rot_z - transform.localEulerAngles.z)));
        }
        
    }

}

