using UnityEngine;
using UnityEngine.UI;

public class AdsCompleteImage : MonoBehaviour
{
    [SerializeField] ShopData _shop;
    [SerializeField] Text _moneyText;

    public void ShowImage()
    {
        var money = Random.Range(100, 1000);
        _moneyText.text = string.Format("Money + {0}", money);
        _shop.AddMoney(money);
        _shop.SerializeData();
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
}
