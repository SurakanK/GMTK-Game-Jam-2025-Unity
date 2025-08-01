using Cinemachine;

public class BasePlayerCharacter : BaseCharacter
{
    void Awake()
    {
        gameObject.tag = GameTag.Player;
    }

    void Start()
    {
        Initialize();
        SetCameraOwner();
        IdleState();

        GamePlayerCharacter.PlayerCharacter = this;
        UIGameplayController.Instance.InitializedUI();

        // Initialize debug
        if (defaultData is PlayerData playerData)
            playerData.InitializedDebug(this);
    }

    private void SetCameraOwner()
    {
        var virtualCameras = FindAnyObjectByType<CinemachineVirtualCamera>();
        if (virtualCameras != null)
        {
            virtualCameras.Follow = transform;
            virtualCameras.LookAt = transform;
        }
    }

    public void IdleState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Idle));
    }

    public void DashState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Dash));
    }

    public void AttackState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Attack));
    }

    public void DeadState()
    {
        ChangeState(GetStateInstance(PlayerStateType.Dead));
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }
}