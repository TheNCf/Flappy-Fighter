using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputRegisterer _inputRegisterer;

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAttacker _playerAttacker;

    private void OnEnable()
    {
        _inputRegisterer.Jump += OnJump;
        _inputRegisterer.Attack += OnAttack;
    }

    private void Update()
    {
        _playerMover.UpdateAngle();
    }

    private void OnDisable()
    {
        _inputRegisterer.Jump -= OnJump;
        _inputRegisterer.Attack -= OnAttack;
    }

    private void OnJump()
    {
        _playerMover.GainAltitude();
    }

    private void OnAttack()
    {

    }
}
