using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Camera _cameraLink;

    [SerializeField] private float _targetInSkyDistance;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var ray = _cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _targetPoint.position = hit.point;
        }
        else
        {
            _targetPoint.position = ray.GetPoint(_targetInSkyDistance);
        }

        transform.LookAt(_targetPoint.position);
    }
}
