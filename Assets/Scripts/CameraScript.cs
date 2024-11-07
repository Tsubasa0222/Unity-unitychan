using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    float angleUp = 60f;
    float angleDown = -60f;

    [SerializeField] GameObject player;
    [SerializeField] Camera cam;

    [SerializeField] float rotate_speed = 0.1f;
    [SerializeField] Vector3 axisPos;

    [SerializeField] float scroll;
    [SerializeField] float scrollLog;

    Vector2 previousTouchPosition;
    bool isTouching = false;

    void Start()
    {
        cam.transform.localPosition = new Vector3(0, 0, -3);
        cam.transform.localRotation = transform.rotation;
    }

    void Update()
    {
        transform.position = player.transform.position + axisPos;

        scroll = Input.GetAxis("Mouse ScrollWheel");
        scrollLog += scroll;

        cam.transform.localPosition
            = new Vector3(cam.transform.localPosition.x,
            cam.transform.localPosition.y,
            cam.transform.localPosition.z + scroll);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 画面右半分のみで操作可能にする
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isTouching = true;
                    previousTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved && isTouching)
                {
                    Vector2 touchDelta = touch.position - previousTouchPosition;
                    previousTouchPosition = touch.position;

                    transform.eulerAngles += new Vector3(
                        -touchDelta.y * rotate_speed,
                        touchDelta.x * rotate_speed,
                        0
                    );
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isTouching = false;
                }
            }
        }

        float angleX = transform.eulerAngles.x;
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}



