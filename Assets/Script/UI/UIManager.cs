using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<UIManager>();
            }
            return _instance;
        }
    }

    public GameObject entryGameCanvas;
    public GameObject townCanvas;

    public void GoToCave()
    {
        BasePlayerCharacter player = DungeonCore.Instance.dungeon.player;
        if (player.TryToGetBuff(out BuffDungeonFee buff))
        {
            player.RemoveBuff(buff);
        }
        else
        {
            if (BaseGamePlay.Currency < GameInstance.GameRule.Fee)
                BaseGamePlay.Outstanding -= GameInstance.GameRule.Fee;
            else
                BaseGamePlay.Currency -= GameInstance.GameRule.Fee;
        }

        DisableButton();
        BaseGamePlay.isGameStart = true;
        entryGameCanvas.gameObject.SetActive(false);
        townCanvas.gameObject.SetActive(false);
        UIGameplayController.Instance.buttonNext.interactable = true;
        UIGameplayController.Instance.buttonLeave.interactable = true;
    }

    public void GoToEntryGame()
    {
        DisableButton();
        entryGameCanvas.gameObject.SetActive(true);
        townCanvas.gameObject.SetActive(false);
        BaseGamePlay.isGameStart = false;
    }

    public void GoToTown()
    {
        DisableButton();
        entryGameCanvas.gameObject.SetActive(false);
        townCanvas.gameObject.SetActive(true);
        BaseGamePlay.isGameStart = false;
        DungeonCore.Instance.dungeon.ClearState();
        BaseGamePlay.Day += 1;

        if (DungeonCore.Instance.dungeon.BgCave != null)
        {
            Destroy(DungeonCore.Instance.dungeon.BgCave.gameObject);
        }
    }

    private void DisableButton()
    {
        UIGameplayController.Instance.buttonLeave.gameObject.SetActive(false);
        UIGameplayController.Instance.buttonNext.gameObject.SetActive(false);
    }
}