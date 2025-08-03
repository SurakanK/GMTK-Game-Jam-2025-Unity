using UnityEngine;
using UnityEngine.UI;

public class TownEvenrManager : MonoBehaviour
{
    public static TownEvenrManager Instance { get; private set; }

     private DialogBox Banker_box;
     private DialogBox Shopkeeper_box;

    [SerializeField] private GameObject Banker;
    [SerializeField] private GameObject Shopkeeper;
    [SerializeField] private GameObject Cave;

    [SerializeField] private Button Banker_btn;
    [SerializeField] private Button Shopkeeper_btn;

    [Header("Dialog List")]
    [SerializeField] DialogInfoSO[] BankerDialogData;
    [SerializeField] DialogInfoSO[] ShopkeeperDialogData;


    [SerializeField] bool IsFirstDay = true;
    [SerializeField] GameObject Tutorial;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep across scenes
        }
    }

    private void Start()
    {
        Banker_box = Banker.GetComponent<DialogBox>();
        Shopkeeper_box = Shopkeeper.GetComponent<DialogBox>();

        Button caveButton = Cave.GetComponent<Button>();
        if (IsFirstDay) caveButton.onClick.AddListener(OnCaveButtonClicked);
    }

    private void OnCaveButtonClicked()
    {
        if (Tutorial != null)
        {
            Tutorial.SetActive(true);
        }

        IsFirstDay = false;
        Debug.Log("Tutorial activated, IsFirstDay set to false.");
    }

    public void UpdateBankNoteDialog()
    {
        Banker_box.SetNewDialog(BankerDialogData[1]);
    }

    public void ResetAllDialog()
    {
        Banker.SetActive(true);
        Shopkeeper.SetActive(true);
        Banker_box.SetNewDialog(BankerDialogData[0]);
        Shopkeeper_box.SetNewDialog(ShopkeeperDialogData[0]);
    }

    public void PlayTransition()
    {
        this.GetComponent<Animation>().Play();
    }

   
}
