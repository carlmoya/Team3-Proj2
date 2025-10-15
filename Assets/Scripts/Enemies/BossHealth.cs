using UnityEngine;

public class BossHealth : HealthBase
{
    // Fields

    private int bossMaxHealth;
    private BossHealthBar healthBar;

    // Methods

    protected void Start()
    {
        // Get reference to health bar
        healthBar = FindFirstObjectByType<BossHealthBar>();

        bossMaxHealth = health;

        healthBar.AnimateFill(1);
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            FindFirstObjectByType<BossHealth>().Modify(-1);
        }
    }

    protected override void TakeDamage()
    {
        base.TakeDamage();

        healthBar.AnimateFill((float)health / bossMaxHealth);
    }

    public override void Die()
    {
        Destroy(gameObject);
        //Invoke(nameof(LoadNextIDK), 0.25f);
    }

    private void LoadNextIDK()
    {
        // Load the main menu
        FindFirstObjectByType<SceneTransitionController>().LoadMainMenu();
    }
}