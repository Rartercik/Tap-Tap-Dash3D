using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerEnding : MonoBehaviour
{
    public StartPositor StartStation;

    [HideInInspector]
    public Animator MovementAnimator;

    [SerializeField] AdsCounter _adsCounter;
    [SerializeField] AdsCompleteImage _adsCompleteImage;

    [SerializeField] Transform _cameraCenter;
    [SerializeField] Collector _collector;
    [SerializeField] float _maxFallingValue;
    [SerializeField] float _maxZRotation;

    [Inject] PlayerMovement _playerMovement;

    private Transform _transform;
    private AdsShower _adsShower;
    private Rigidbody _rb;
    private float _minY;

    private void Start()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _minY = _transform.position.y - _maxFallingValue;
        _adsShower = new AdsShower(_adsCounter, _adsCompleteImage);
        _adsShower.TryShowAds();
    }
    private void Update()
    {
        if (_transform.position.y < _minY || !AdmissibleAngle(_transform.eulerAngles.z))
        {
            MovementAnimator.SetBool("Die", true);
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            SwitchMovementEnabled(false);
        }
    }

    public void RestartLevel(StartPositor startStation)
    {
        ReloadLevel(startStation);
        ReloadPlayer(startStation.transform);
        _adsShower.TryShowAds();
        
    }
    public void RestartLevel()
    {
        RestartLevel(StartStation);
    }
    private void ReloadLevel(StartPositor startPositor)
    {
        ActivateChildren(startPositor.CollectablesParent);
        ActivateChildren(startPositor.ActionsParent);
        if (startPositor.ActionsParent != null)
            _playerMovement.NextActionPlate = startPositor.ActionsParent.GetChild(0).GetComponent<ActionPlate>();
    }
    private void ReloadPlayer(Transform startStation)
    {
        MovementAnimator.SetBool("Die", false);
        SwitchMovementEnabled(true);

        _transform.position = startStation.position;
        _transform.rotation = Quaternion.Euler(0, 0, 0);
        _cameraCenter.rotation = Quaternion.Euler(0, 0, 0);
        _playerMovement.StopRotation();
        _playerMovement.Movement.Direction = Vector3.forward;
        _playerMovement.ChangeValues(_playerMovement.LastUpdate);
        _collector.ResetValues();
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
