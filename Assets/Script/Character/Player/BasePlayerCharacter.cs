
public class BasePlayerCharacter : BaseCharacter
{
    void Awake()
    {
        gameObject.tag = GameTag.Player;
    }

    public void InitializePlayer()
    {
        Initialize();
        IdleState();

        GamePlayerCharacter.PlayerCharacter = this;

        // Initialize debug
        if (defaultData is PlayerData playerData)
            playerData.InitializedDebug(this);
    }

    public void IdleState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Idle));
    }

    public void AttackState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Attack));
    }

    public void DeadState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Dead));
    }

    public void TakeDamageState()
    {
        ChangeState(GetStateInstance(PlayerStateType.TakeDamage));
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }
}