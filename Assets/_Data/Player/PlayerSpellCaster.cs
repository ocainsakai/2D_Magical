using UnityEngine;

public class PlayerSpellCaster : MonoBehaviour
{
    protected void Start()
    {
        InvokeRepeating(nameof(Test), 1f, 1f);
    }
    protected void Test()
    {
        SpellSpawner.Instance.Spawn("FireBall");
    }
}
