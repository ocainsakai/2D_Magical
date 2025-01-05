using UnityEngine;

public class InfiniteChildMover : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float mapChunkSize = 200f * 0.15f;
    [SerializeField] protected float distanceThreshold = 1.5f;
    // Update is called once per frame
    protected virtual void Reset()
    {
        this.LoadTarget();

    }

    protected virtual void LoadTarget()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": Load Target", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.UpdateChildren();
    }

    protected virtual void UpdateChildren()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform child = this.transform.GetChild(i);
            Vector3 distance = player.position - child.position;
            if (Mathf.Abs(distance.x) > mapChunkSize * distanceThreshold)
            {
                child.position += Vector3.right * mapChunkSize * 3 * Mathf.Sign(distance.x);
            }
            if (Mathf.Abs(distance.y) > mapChunkSize * distanceThreshold)
            {
                child.position += Vector3.up * mapChunkSize * 3 * Mathf.Sign(distance.y);
            }
        }
    }
}
