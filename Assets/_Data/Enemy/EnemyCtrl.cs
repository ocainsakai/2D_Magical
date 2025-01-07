using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent (typeof(CircleCollider2D))]
public class EnemyCtrl : CtrlBase
{
    

    protected override void Reset()
    {
        int layer = LayerMask.NameToLayer("Enemy");
        base.Reset();
        SetLayerRecursively(this.gameObject, layer);
    }
    //protected virtual void LoadSO()
    //{
    //    if (enemySO == null)
    //    {
    //        enemySO = GetComponent<EnemySO>();
    //    }
    //}
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }
}
