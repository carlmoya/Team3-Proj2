using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHeart : MonoBehaviour
{
    // Fields

    public Sprite[] hearts;

    private Image heart;
    private PlayerHealth playerHealth;

    private int currentHealth;
    private float heartBeatsPerSecond = 1f;

    private Coroutine damageAnimation = null;

    // Methods

    private void Start()
    {
        // Get reference to heart
        heart = GetComponent<Image>();

        // Get reference to player health
        playerHealth = FindFirstObjectByType<PlayerHealth>();

        // Start heart beat animation loop
        StartCoroutine(HeartBeatAnimationLoop());
    }

    private void Update()
    {
        UpdateHeart();
        CheckForDamage();
    }

    private void UpdateHeart()
    {
        // Store current health for readability
        int health = playerHealth.health;

        // Update heart sprite and beat rate based on health
        if (health <= 1)
        {
            // Critical health: empty heart, fast heart beat
            heart.sprite = hearts[0];
            heartBeatsPerSecond = 3f;
        }
        else if (health == 2)
        {
            // Moderate health: half heart, medium heart beat
            heart.sprite = hearts[1];
            heartBeatsPerSecond = 2f;
        }
        else
        {
            // Full or unknown health: full heart, normal heart beat
            heart.sprite = hearts[2];
            heartBeatsPerSecond = 1f;
        }
    }

    private void CheckForDamage()
    {
        if (TookDamage() == true)
        {
            // Stop any running damage animation
            if (damageAnimation != null) { StopCoroutine(damageAnimation); }

            // Start a new damage animation
            damageAnimation = StartCoroutine(DamageAnimation());
        }
    }

    // Return Methods

    private bool TookDamage()
    {
        // Compare current health flag to actual player health
        bool tookDamage = currentHealth != playerHealth.health && playerHealth.health < 3;

        // Update current health flag from last frame
        currentHealth = playerHealth.health;

        // Return true if the player took damage
        return tookDamage;
    }

    // Coroutines

    private IEnumerator HeartBeatAnimationLoop()
    {
        while (true) // Runs forever unless stopped
        {
            // Wait for heart beat animation
            yield return HeartBeatAnimation();

            // Wait to start the next heart beat
            yield return new WaitForSeconds(1f / heartBeatsPerSecond);
        }
    }

    private IEnumerator HeartBeatAnimation()
    {
        // Wait for heart to scale up
        yield return HeartScaleAnimation(Vector3.one * 1.25f);

        // Wait for heart to scale down
        yield return HeartScaleAnimation(Vector3.one * 1f);

        // Wait for heart to scale up
        yield return HeartScaleAnimation(Vector3.one * 1.25f);

        // Wait for heart to scale down
        yield return HeartScaleAnimation(Vector3.one * 1f);
    }

    private IEnumerator HeartScaleAnimation(Vector3 targetScale)
    {
        // Customize animation curve
        AnimationCurve smoothAnimationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        // Get the start scale for the animation
        Vector3 startScale = transform.localScale;

        // Customize animation duration
        float duration = 0.1f;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / duration;

            // Interpolate over time
            Vector3 currentScale = Vector3.Lerp(startScale, targetScale, smoothAnimationCurve.Evaluate(time));

            // Apply animation
            transform.localScale = currentScale;

            // Wait for next frame
            yield return null;
        }

        // Ensure finished animation state
        transform.localScale = targetScale;
    }

    private IEnumerator DamageAnimation()
    {
        // Customize animation duration
        float duration = 1f;

        // Track & increase the elapsed time of the animation
        for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
        {
            // Normalize elapsed time
            float time = elapsedTime / duration;

            // Interpolate over time
            Color currentColor = Color.Lerp(Color.red, Color.white, time);

            // Apply animation
            heart.color = currentColor;

            // Wait for next frame
            yield return null;
        }

        // Ensure finished animation state
        heart.color = Color.white;
    }
}
