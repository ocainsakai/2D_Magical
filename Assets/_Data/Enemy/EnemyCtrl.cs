using UnityEngine;

public class EnemyCtrl : MyMonoBehaviour
{
    [SerializeField] protected EnemySpawner _spawner;
    public EnemySpawner Spawner => _spawner;


}
