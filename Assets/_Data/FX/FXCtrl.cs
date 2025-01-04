using UnityEngine;

public class FXCtrl : MyMonoBehaviour
{
    [SerializeField] protected ParticleSystem _particleSystem;
    public ParticleSystem Particle => _particleSystem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParticleSystem();
    }
   
    protected virtual void LoadParticleSystem()
    {
        if (this._particleSystem != null) return;
        this._particleSystem = transform.GetComponentInChildren<ParticleSystem>();
        Debug.Log(transform.name + ": LoadParticleSystem", gameObject);
    }
}
