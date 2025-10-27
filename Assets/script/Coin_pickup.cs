using UnityEngine;
using TMPro;

public class CoinCollector3D : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshPro coinsText;
    
    [Header("Collection Effects")]
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private ParticleSystem collectEffect;
    
    private int coinsCount = 0;
    private AudioSource audioSource;

    private void Start()
    {
        // Initialize audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
            
        UpdateCoinsUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        // Increase coin count
        coinsCount++;
        
        // Play collection effects
        PlayCollectionEffects(coin.transform.position);
        
        // Destroy the coin
        Destroy(coin);
        
        // Update UI
        UpdateCoinsUI();
    }

    private void PlayCollectionEffects(Vector3 position)
    {
        // Play sound
        if (collectSound != null && audioSource != null)
            audioSource.PlayOneShot(collectSound);
            
        // Play particle effect
        if (collectEffect != null)
        {
            ParticleSystem effect = Instantiate(collectEffect, position, Quaternion.identity);
            Destroy(effect.gameObject, 2f);
        }
    }

    private void UpdateCoinsUI()
    {
        // Update the Text Mesh Pro UI element
        if (coinsText != null)
            coinsText.text = $"Coins: {coinsCount}";
        else
            Debug.LogWarning("Coins Text reference is not set in the inspector!");
    }

    // Public methods for external access
    public int GetCoinsCount()
    {
        return coinsCount;
    }

    public void AddCoins(int amount)
    {
        coinsCount += amount;
        UpdateCoinsUI();
    }

    public void SetCoins(int amount)
    {
        coinsCount = amount;
        UpdateCoinsUI();
    }
}