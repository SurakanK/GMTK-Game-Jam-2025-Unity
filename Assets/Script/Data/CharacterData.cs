
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CharacterData : BaseObject
{
    [Header("Character")]
    public SkeletonAnimation prefab;

    [Header("Stats")]
    public StatsData stats;

    [Header("Buff")]
    public List<BaseBuff> defaultBuff;

    [Header("Sound Setting")]
    public AudioClip sfxIdle;
    public AudioClip sfxAttack;
    public AudioClip sfxDead;
    public AudioClip sfxGethit;
    public AudioClip sfxSpawn;
    public AudioClip takeDamage;
    public AudioClip hp;

    public void Apply(BaseCharacter owner)
    {
        // Apply Stats
        stats.Apply(owner);

        // Apply buff
        ApplyBuff(owner);
    }

    private void ApplyBuff(BaseCharacter owner)
    {
        foreach (BaseBuff buff in defaultBuff)
        {
            owner.AddBuff(buff);
        }
    }

    public CharacterData Clone()
    {
        return Instantiate(this);
    }
}