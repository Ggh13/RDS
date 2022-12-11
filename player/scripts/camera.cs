using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject center;
    public GameObject player;
    public Vector3 delta;
    public mouseDetect md;

    public float rot_speed = 2f;
    public float y_rot = 0;
    public float x_rot = 0;

    public float y_height;

    public Transform target;
    public Vector3 offset;
    public float sensitivity = 3;
    public float limit = 80;
    public float zoom = 0.25f;
    public float zoomMax = 10;
    public float zoomMin = 3;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        y_rot = transform.rotation.y;
        x_rot = transform.rotation.x;

        	limit = Mathf.Abs(limit);
		if (limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
		transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        delta = new Vector3( center.transform.position.x, center.transform.position.y, center.transform.position.z) - new Vector3(transform.position.x, transform.position.y, transform.position.z);
       //transform.RotateAround(center.transform.position, new Vector3(0, delta_rot, 0), 2f);
       // transform.LookAt(new Vector3(0, player_stats.transform.position.y, 0) , new Vector3(0, delta_rot, 0));
        transform.position += delta / 2;

        y_rot = y_rot + md.deltaMousePositionX * rot_speed;

        x_rot = x_rot + md.deltaMousePositionX * rot_speed;

        if (Input.GetMouseButton(0))
        {
            x = transform.localEulerAngles.y + Input.GetAxis("Mouse x") * sensitivity;
            y += Input.GetAxis("Mouse y") * sensitivity;
            y = Mathf.Clamp(y, -limit, limit);
            transform.localEulerAngles = new Vector3(-y, x, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
        //transform.rotation = Quaternion.Euler(y_rot, x_rot, transform.rotation.z);
    }
}
