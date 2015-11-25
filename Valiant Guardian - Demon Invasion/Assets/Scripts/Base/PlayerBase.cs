using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    private int baseLevel;
    private Text enemyLimitText;
    public int enemyLimit = 25;

    void Awake()
    {
        baseLevel = 1;
        enemyLimitText = GameObject.Find("EnemyLimitText").GetComponent<Text>();
        enemyLimitText.text = enemyLimit.ToString();
    }

    public void AttackBase()
    {
        enemyLimit--;
        enemyLimitText.text = enemyLimit.ToString();
        if (enemyLimit <= 0)
        {
            enemyLimitText.text = "You Loseee";
            Time.timeScale = 0;
        }
    }

    public bool isAttackAble()
    {
        return enemyLimit > 0;
    }

    public void PlayerWin()
    {
        enemyLimitText = GameObject.Find("EnemyLimitText").GetComponent<Text>();
        enemyLimitText.text = "You Wiiiin";
        Time.timeScale = 0;
    }

    public void Upgrade()
    {
        baseLevel++;
        if (baseLevel == 2)
        {
            enemyLimit = 30;
        }
        if (baseLevel == 3)
        {
            enemyLimit = 35;
        }
        if (baseLevel == 4)
        {
            enemyLimit = 40;
        }
        if (baseLevel == 5)
        {
            enemyLimit = 50;
        }
    }
}