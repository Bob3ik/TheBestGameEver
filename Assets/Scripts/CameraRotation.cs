using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform _cameraAxisTransform;

    [SerializeField, Range(0f, 1000f)] private float _rotationSpeed = 300f;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;

    void FixedUpdate()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * _rotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAngleX = _cameraAxisTransform.localEulerAngles.x - Time.deltaTime * _rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, _minAngle, _maxAngle);
        _cameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
