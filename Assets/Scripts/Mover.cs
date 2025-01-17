using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _way;

    private Vector3[] _waypoints;
    private float _speed;
    private int _currentWaypoint = 0;

    private void Start()
    {
        AddWaypoints();
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint])
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);
    }

    private void AddWaypoints()
    {
        _waypoints = new Vector3[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _waypoints[i] = _way.GetChild(i).position;
        }
    }
}