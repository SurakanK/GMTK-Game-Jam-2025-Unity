using UnityEngine;

public class UIDevToolsManager : MonoBehaviour
{
#if !DEBUG_TOOLS
    void Awake()
    {
        Destroy(gameObject);
    }
#endif
}