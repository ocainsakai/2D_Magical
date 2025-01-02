using UnityEngine;

public abstract class CharacterAbstract : MyMonoBehaviour
{
    [Header("Character Abtract")]
    [SerializeField] protected CharacterCtrl _characterCtrl;
    public CharacterCtrl CharacterCtrl => _characterCtrl; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (this._characterCtrl != null) return;
        this._characterCtrl = transform.parent.GetComponent<CharacterCtrl>();
        Debug.Log(transform.name + ": LoadCharacterCtrl", gameObject);
    }
}
