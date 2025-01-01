using UnityEngine;

public class CharacterCtrl : MyMonoBehaviour
{
    [SerializeField] protected CharacterCtrl instance;
    public CharacterCtrl Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (this.instance != null) return;
        this.instance = GetComponent<CharacterCtrl>();
        Debug.LogWarning(transform.name + ": LoadCharacterCtrl", gameObject);
    }


}
