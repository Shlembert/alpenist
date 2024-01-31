using UnityEngine;

public class DangerDistanse : MonoBehaviour
{
    private FixedJoint joint;
    [SerializeField] private Target tg;

    private void Start()
    {
        tg.gap = false;
        joint = GetComponent<FixedJoint>();
    }
    void Update()
    {
        if (tg.gap && joint != null) joint.GetComponent<FixedJoint>().breakForce = 0;
        else return;
    }
}
