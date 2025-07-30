using UnityEngine.Events;

partial class BaseCharacter
{
    public int MaxHealth => Stats.maxHealth;
    public int MaxStamina => Stats.maxHealth;

    public StatsData _status;
    public StatsData Stats
    {
        get { return _status; }
        set { _status = value; }
    }

    public int currentHealth;
    public int currentStamina;

    private void ApplyStats()
    {
        defaultData.Apply(this);
    }
}