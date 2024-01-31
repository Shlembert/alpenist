using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float speed;
    [SerializeField] private Target target;

    private Vector3 dis;
    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Draggable")
            {
                toDrag = hit.transform;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                dis = myCamera.WorldToScreenPoint(previousPosition);
                posX = Input.mousePosition.x - dis.x;
                posY = Input.mousePosition.y - dis.y;

                SetDraggingProperties(toDragRigidbody);

                touched = true;
            }
        }

        if (touched && Input.GetMouseButton(0))
        {
            dragging = true;

            float posXNow = Input.mousePosition.x - posX;
            float posYNow = Input.mousePosition.y - posY;
            Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

            Vector3 worldPos = myCamera.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x, worldPos.y, 0.0f);
           
            toDragRigidbody.velocity = worldPos / (Time.deltaTime * (speed + target.dist));

            previousPosition = toDrag.position;
        }

        if (dragging && !Input.GetMouseButton(0))
        {
            dragging = false;
            touched = false;
            previousPosition = Vector3.zero;
            SetFreeProperties(toDragRigidbody);
        }
    }

    private void SetDraggingProperties(Rigidbody rb)
    {
        rb.useGravity = false;
    }

    private void SetFreeProperties(Rigidbody rb)
    {
        rb.useGravity = true;
    }
}
