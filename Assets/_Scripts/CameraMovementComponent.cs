using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementComponent : MonoBehaviour {

    public Vector3 Offset;

    public float SpeedDamp = 2.0f;

    public GameObject CameraFocus;
	// Use this for initialization
	void Start () {
        Offset = transform.position - CameraFocus.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 NewLocation = CameraFocus.transform.position + Offset;

        transform.position = Vector3.Lerp(transform.position, NewLocation, SpeedDamp * Time.deltaTime);


	}
}
