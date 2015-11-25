using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    private int countCoin = 0; //reserve
    private int countTempCoin = 0;
    private int income = 0;
    private Text coinText; //tampilkan reserve + temp
    private PlayerBase playerBase;

    void Awake()
    {
        coinText = transform.FindChild("CoinText").GetComponent<Text>();
        //Always load coin from dataPlayer
        countCoin = DataPlayer.getInstance().Coin;
        //coinText.text = countCoin.ToString();
        coinText.text = (countCoin + countTempCoin).ToString();
        playerBase = GameObject.Find("PlayerBase").GetComponent<PlayerBase>();
    }

    public void resetTempCoin()
    {
        countTempCoin = 0;
    }

    public void addCoin()
    {
        countTempCoin += 10;
        //set coin data in DataPlayer
        //DataPlayer.getInstance().Coin = countCoin;
        //coinText.text = countCoin.ToString();
        coinText.text = (countCoin + countTempCoin).ToString();
        //always save coin data for every time get coin
        //todo in Future will be improved, because can (maybe) be a killer performance
        //because every state coin will access disk to write file
    }

    public void addToReserve()
    {
        countCoin = countTempCoin + countCoin;
        //DataPlayer.getInstance().Coin = countCoin;
    }

    public void subtractCoin(int amount)
    {
        countTempCoin -= amount;
        if (countTempCoin < 0)
        {
            countCoin += countTempCoin;
            resetTempCoin();
        }
    }

    public void incomeRegen()
    {
        CancelInvoke();
        if (playerBase.enemyLimit > 40)
            income = 30;
        else if (playerBase.enemyLimit > 30)
            income = 25;
        else if (playerBase.enemyLimit > 20)
            income = 20;
        else if (playerBase.enemyLimit > 10)
            income = 15;
        else
            income = 10;
        InvokeRepeating("regenAdd", 2f, 2f);
    }

    public void regenAdd()
    {
        countTempCoin += income;
        coinText.text = (countCoin + countTempCoin).ToString();
    }

}
