using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _altitudeGainAmount = 5.0f;
    [Space(10)]
    [SerializeField] private float _maxTilt = 20.0f;
    [SerializeField] private float _minTilt = -25.0f;
    [SerializeField] private float _clickTiltSpeed = 10.0f;
    [SerializeField] private float _minTiltSpeed = 0.5f;
    [SerializeField] private float _decreaseTiltSpeed = 0.5f;

    private Rigidbody2D _rigidbody;

    private float _desiredTilt = 0.0f;
    private float _desiredTiltSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _desiredTiltSpeed = _decreaseTiltSpeed;
    }

    public void UpdateAngle()
    {
        _desiredTiltSpeed = Mathf.Clamp(_desiredTiltSpeed - _decreaseTiltSpeed * Time.deltaTime, _minTiltSpeed, _clickTiltSpeed);
        _desiredTilt = Mathf.Lerp(_desiredTilt, _minTilt, _desiredTiltSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, _desiredTilt);
    }

    public void GainAltitude()
    {
        _rigidbody.velocity = new Vector2(0.0f, _altitudeGainAmount);
        _decreaseTiltSpeed = _clickTiltSpeed;
        _desiredTilt = _maxTilt;
    }
}
