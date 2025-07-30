using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public partial class UIBase : MonoBehaviour
{
    public GameObject root;
    public bool isHideOnAwake;

    public UnityEvent onShow = new UnityEvent();
    public UnityEvent onHide = new UnityEvent();

    private bool _init = true;
    internal bool IsActive => gameObject.activeInHierarchy;
    
    void OnEnable()
    {
        if (_init)
        {
            SetActive(!isHideOnAwake);
            _init = false;
        }
    }

    void OnDestroy()
    {

    }

    public void SetActive(bool isActive)
    {
        if (isActive)
        {
            OnShow();
        }
        else
        {
            OnHide();
        }
    }

    public virtual void OnShow()
    {
        _init = false;
        onShow?.Invoke();
        if (root)
            root.SetActive(true);
    }

    public async UniTask OnShowAsync()
    {
        OnShow();
        await UniTask.Yield();
    }

    public virtual void OnHide()
    {
        onHide?.Invoke();
        if (root)
            root.SetActive(false);
    }
}