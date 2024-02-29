using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void GetTargetPoint(Transform targetPoint)
    {
        _mover.GetTargetPoint(targetPoint);
    }
}
