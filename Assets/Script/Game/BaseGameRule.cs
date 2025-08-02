using UnityEngine;

[CreateAssetMenu(fileName = "Game Rule", menuName = "Game/Game Rule")]
public class BaseGameRule : ScriptableObject
{
    [Header("Behaviour Data")]

    [SerializeField]
    private int _startLevel;
    public int StartLevel => _startLevel;

    [SerializeField]
    private int _startCurrency;
    public int StartCurrency => _startCurrency;

    [SerializeField]
    private int _outstanding;
    public int Outstanding => _outstanding;

    [SerializeField]
    private int _limitSlot;
    public int LimitSlot => _limitSlot;
}