using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerEnding : MonoBehaviour
{
    public Transform StartStation;

    [HideInInspector]
    public Animator MovementAnimator;

    [SerializeField] AdsShower _adsShower;

    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] Transform _camera;
    [SerializeField] Collector _collector;
    [SerializeField] float _maxFallingValue;
    [SerializeField] float _maxZRotation;

    private Rigidbody _rb;
    private float _minY;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _minY = transform.position.y - _maxFallingValue;
    }
    private void Update()
    {
        if (transform.position.y < _minY || !AdmissibleAngle(transform.eulerAngles.z))
        {
            MovementAnimator.SetBool("Die", true);
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            SwitchMovementEnabled(false);
        }
    }

    public void RestartLevel(Transform startStation)
    {
        MovementAnimator.SetBool("Die", false);
        SwitchMovementEnabled(true);

        var startPositor = startStation.gameObject.GetComponent<StartPositor>();
        ActivateChildren(startPositor.CollectablesParent);
        ActivateChildren(startPositor.ActionsParent);
        if(startPositor.ActionsParent != null)
            _playerMovement.NextActionPlate = startPositor.ActionsParent.GetChild(0).GetComponent<ActionPlate>();

        transform.position = startStation.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _camera.rotation = Quaternion.Euler(0, 0, 0);
        _playerMovement.StopRotation();
        _playerMovement.Movement.Direction = Vector3.forward;
        _playerMovement.ChangeValues(_playerMovement.LastUpdate);
        _collector.ResetValues();

        _adsShower.UpdateAds();
        
    }
    public void RestartLevel()
    {
        RestartLevel(StartStation);
    }
    private void SwitchMovementEnabled(bool arg)
    {
        _playerMovement.enabled = arg;
        _playerMovement.Movement.enabled = arg;
        _playerMovement.RotationMovement.enabled = arg;
        _playerMovement.VerticalMovement.enabled = arg;
    }
    private bool AdmissibleAngle(float angle)
    {
        return Mathf.Abs(angle) < _maxZRotation || Mathf.Abs(angle) > 360 - _maxZRotation;
    }
    private void ActivateChildren(Transform parent)
    {
        if (parent != null)
        {
            foreach (Transform child in parent)
                child.gameObject.SetActive(true);
        }
    }
}
