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
            v3.z = 10.0F;
            wantedPosition = Camera.main.ScreenToWorldPoint(v3);
        }

        Vector3 offset = wantedPosition - transform.position;

        print(offset.magnitude);

        if (offset.magnitude > 0.1)
        {
            transform.Translate(offset.normalized * speed);
        }
    }

}

