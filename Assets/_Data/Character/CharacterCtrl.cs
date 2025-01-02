using UnityEngine;

public class CharacterCtrl : MyMonoBehaviour
{
    [SerializeField] protected static CharacterCtrl _instance;
    public static CharacterCtrl Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (CharacterCtrl._instance != null) Debug.LogError("Only 1 GameCtrl allow to exist");
        CharacterCtrl._instance = this;
    }

}
