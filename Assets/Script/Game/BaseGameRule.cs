using UnityEngine;

[CreateAssetMenu(fileName = "Game Rule", menuName = "Game/Game Rule")]
public class BaseGameRule : ScriptableObject
{
    [Header("Behaviour Data")]

    [SerializeField]
    private int _dashCost;
    public int DashCost => _dashCost;    
    
}