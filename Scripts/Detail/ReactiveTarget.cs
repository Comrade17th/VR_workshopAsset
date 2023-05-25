using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public bool isFollow = false; // true if it holded by player
    public Transform objectToFollow;
    private Vector3 deltaPos;

    private void Update()
    {
        if (isFollow)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        transform.position = objectToFollow.position + deltaPos;
    }

    public void Drop()
    {
        isFollow = false;
        objectToFollow = null;
        deltaPos = Vector3.zero;
    }

    public void ReactToHit(Transform objectToFollow)
    {// ¬ Метод, вызванный сценарием стрельбы.
        transform.position = objectToFollow.position;
        deltaPos = transform.position - objectToFollow.position;
        this.objectToFollow = objectToFollow;
        isFollow = true;
        //StartCoroutine(Die());
    }

}