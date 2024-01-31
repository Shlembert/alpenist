using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Transform P0, P1, P2, P3;
    [SerializeField]
    private float dangerDistance = 4f;
    public float dist;
    public bool gap = false;

    [Range(0, 1)]
    public float t;
    //public Text distanceTxt;

    void Update()
    {
        transform.position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, t);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, t));

        dist = Vector3.Distance(P1.position, P2.position);

        if (dist > dangerDistance)
        {
            gap = true;
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Time.timeScale = 0;
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = P0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}
