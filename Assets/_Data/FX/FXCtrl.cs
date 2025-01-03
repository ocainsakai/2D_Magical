using UnityEngine;

public class FXCtrl : MyMonoBehaviour
{
    [SerializeField] protected ParticleSystem _particleSystem;
    public ParticleSystem ParticleSystem => _particleSystem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParticalSystem();
    }
    protected virtual void LoadParticalSystem()
    {
        if (_particleSystem != null) return;
        this._particleSystem = GetComponentInChildren<ParticleSystem>();
        Debug.LogWarning(transform.name + ": LoadFXParticleSystem ", gameObject);
    }
}
