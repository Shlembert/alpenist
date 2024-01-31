using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 distance;

    public float speed;
    public float lookSpeed;

    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);

        Vector3 positionToGo = target.position + distance;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, speed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
