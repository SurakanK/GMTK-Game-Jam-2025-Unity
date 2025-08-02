using UnityEngine.Events;

partial class BaseCharacter
{
    public int MaxHealth => Stats.maxHealth;

    public StatsData _status;
    public StatsData Stats
    {
        get { return _status; }
        set { _status = value; }
    }

    private int _currentHealth;
    public int currentHealth
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (!IsEnemy())
                GameEvent.Instance.EventHealthChange?.Invoke(_currentHealth, MaxHealth);
        }
    }

    private void ApplyStats()
    {
        defaultData.Apply(this);
    }
}