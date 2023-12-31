using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _pos;
    private void Awake()
    {
        if (!_player)
            _player = FindObjectOfType<_PlayerController_>().transform;
    }

    
    void Update()
    {
        _pos = _player.position;
        _pos.z = -10f;

        transform.position = Vector3.Lerp(transform.position, _pos, 5.25f * Time.deltaTime);
    }
}
