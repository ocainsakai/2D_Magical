using UnityEngine;

public class Level : MonoBehaviour
{
    public int level = 1;
    public int levelMax = 100;
    public int currentXP = 0;
    public int xpToNextLevel = 100;


    public delegate void LevelUpEvent(int newLevel);
    public event LevelUpEvent OnLevelUp;


    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log($"Gained {amount} XP. Current XP: {currentXP}/{xpToNextLevel}");

        // Kiểm tra nếu đủ XP để lên cấp
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.25f); // Tăng yêu cầu XP
        Debug.Log($"Level Up! New Level: {level}. XP for next level: {xpToNextLevel}");

        OnLevelUp?.Invoke(level); // Gửi sự kiện Level Up
    }
}
