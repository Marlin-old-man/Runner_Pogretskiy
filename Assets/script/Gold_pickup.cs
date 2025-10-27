using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinPicker : MonoBehaviour

{
    [Header("UI References")]
    [SerializeField] private TextMeshPro coinText;

    [Header("Настройки")]
    public int coinValue = 1; // Количество очков за монетку
    public string playerTag = "Player"; // Тег игрока

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем тэг объекта, который вошел в триггер
        if (other.CompareTag(playerTag))
        {
            PickCoin();
        }
    }

    void PickCoin()
    {
        void UpdateUI()
        {
            if (coinText != null)
                coinText.text = coinText.text + coinValue;

            // Уничтожаем монетку
            Destroy(gameObject);
        }
    }
}