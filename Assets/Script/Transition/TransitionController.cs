using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{    
    public static TransitionController Instance { get; private set; }

    [SerializeField] Animator animator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Optional: enforce singleton
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Start");
        }*/
    }

    public async UniTask TriggerFadeOutTransition()
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator not set in TransitionController!");
            return;
        }

        Debug.Log("Triggering transition.");
        animator.SetTrigger("Start");
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
    }

    public Animator GetAnimator() => animator;
}
