using UnityEngine;

[RequireComponent(typeof(LevelStation))]
public class CenterConcentrator : MonoBehaviour
{
    [SerializeField] Transform _center;

    private LevelStation _station;
    private Rigidbody _alianRigidbody;
    private Vector3 _alianStartPosition;
    private bool _startGoing;
    private float _progress;

    private void Start()
    {
        _station = GetComponent<LevelStation>();
    }
    private void Update()
    {
        if (_startGoing)
        {
            if (_progress < 1)
            {
                GoToCenter(_alianStartPosition);
            }
            else
            {
                _station.InitializeLevel();
                _startGoing = false;
                _progress = 0;
            }
        }
    }

    public void StartGoToCenter(GameObject alian)
    {
        _alianRigidbody = alian.GetComponent<Rigidbody>();
        _alianStartPosition = alian.transform.position;
        _startGoing = true;
    }

    private void GoToCenter(Vector3 startPosition)
    {
        _progress += Time.deltaTime;
        var playerPosition = Vector3.Lerp(startPosition, _center.position, _progress);
        _alianRigidbody.MovePosition(playerPosition);
    }
}
