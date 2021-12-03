using Enemy.DAL;
using Infrastructure.DAL;
using Player.DAL;
using Player.Inventroy.DAL;
using UnityEngine;

public class ScriptableObjectsContainer : MonoBehaviour
{
    public static ScriptableObjectsContainer Instance;

    [Header("Player Data")]
    public PlayerData CurrentPlayerData;
    public  AttackDetectionData PlayerAttackStatsData;
    public CameraFollowData CameraFollowData;
    public PlayerHealthData PlayerHealthData;

    [Header("Enenmy Data")]
    public  EnemyData EnenmySkeletonData;
    public EnemyAttackData EnemyAttackData;

    [Header("Infrastructure Data")]
    public  LevelsData InitialLevelData;
    public LevelsData MainMenuLevelData;

    [Header("Inventory Data")]
    public InventoryData PlayerInventoryData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
