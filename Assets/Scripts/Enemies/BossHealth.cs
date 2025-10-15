using UnityEngine;

public class BossHealth : HealthBase
{
    // Fields

    private BossHealthBar healthBar;

    // Methods

    protected void Start()
    {
        healthBar = FindFirstObjectByType<BossHealthBar>();

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

        healthBar.AnimateFill((float)health / 5);
    }

    public override void Die()
    {
        Invoke(nameof(LoadNextIDK), 0.25f);
    }

    private void LoadNextIDK()
    {
        // Load the main menu
        FindFirstObjectByType<SceneTransitionController>().LoadMainMenu();
    }
}