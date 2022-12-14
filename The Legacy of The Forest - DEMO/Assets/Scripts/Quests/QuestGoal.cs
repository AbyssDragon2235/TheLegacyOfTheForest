using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }
    public void ItemDestroyed()
    {
        if (goalType == GoalType.Destroy)
            currentAmount++;
    }
    public void ItemSold()
    {
        if (goalType == GoalType.Sell)
            currentAmount++;
    }
}

public enum GoalType
{
    Gathering,
    Destroy,
    Sell
}
