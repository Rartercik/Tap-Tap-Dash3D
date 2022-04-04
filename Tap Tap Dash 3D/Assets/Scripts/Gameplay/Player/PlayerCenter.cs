using UnityEngine;

public class PlayerCenter : MonoBehaviour
{
	[SerializeField] Transform _player;

    private Transform _transform;
	
    private void Start()
    {
        _transform = transform;
        _transform.position = _player.position;
    }
    private void Update()
    {
        _transform.position = _player.position;
    }
}
