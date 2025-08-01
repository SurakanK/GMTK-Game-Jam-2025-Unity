using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class UIVFXManager : MonoBehaviour
{
    [Header("UI VFX")]
    [SerializeField] public List<VFXEntry> vfxEntries;

    private Dictionary<VFXType, GameObject> vfxMap;

    public static UIVFXManager _instance;
    public static UIVFXManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIVFXManager>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        vfxMap = vfxEntries.ToDictionary(e => e.type, e => e.gameObject);
    }

    public void Play(VFXType type)
    {
        if (vfxMap.TryGetValue(type, out var gameObject))
        {
            Show(gameObject).Forget();
        }
    }

    private async UniTask Show(GameObject gameObject)
    {
        gameObject.SetActive(true);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        gameObject.SetActive(false);
    }

    public enum VFXType
    {
        Attack,
        TakeDamage,
    }

    [Serializable]
    public class VFXEntry
    {
        public VFXType type;
        public GameObject gameObject;
    }
}

