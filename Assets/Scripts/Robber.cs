using UnityEngine;

public class Robber : MonoBehaviour
{
    [SerializeField] private House _house;
    [SerializeField] private float _speed = 5;

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _house.transform.position,
            _speed * Time.deltaTime
        );
    }
}
