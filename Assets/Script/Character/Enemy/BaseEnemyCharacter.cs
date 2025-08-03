
using Unity.VisualScripting;
using UnityEngine;

public partial class BaseEnemyCharacter : BaseCharacter
{
    public EnemyData EnemyData;
    AudioSource EnemySound;
    public void Initialized(EnemyData enemyData)
    {
        EnemyData = enemyData;
        defaultData = enemyData;
        Initialize();
        SpawnEntity();
        //Spawn SFX
        EnemySound.clip = EnemyData.sfxSpawn;
        EnemySound.Play();
        IdleState();
    }

    public void IdleState()
    {
        ChangeState(GetStateInstance(EnemyStateType.Idle));
    }

    public void AttackState()
    {
        EnemySound.clip = EnemyData.sfxAttack;
        EnemySound.Play();
        ChangeState(GetStateInstance(EnemyStateType.Attack));
    }

    public void DeadState()
    {
        EnemySound.clip = EnemyData.sfxDead;
        EnemySound.Play();
        ChangeState(GetStateInstance(EnemyStateType.Dead));
    }

    public override void Dead()
    {
        Factory.Instance.Destroy(this);
    }

    private void Start()
    {
        if (this.GetComponent<AudioSource>() == null)
        {
            EnemySound = this.AddComponent<AudioSource>();
        }
        else EnemySound = this.GetComponent<AudioSource>();

    }
}