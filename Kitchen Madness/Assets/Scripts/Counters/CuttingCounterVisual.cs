using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";
    
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounterOnOnCut;
    }

    private void CuttingCounterOnOnCut(object sender, EventArgs e)
    {
        animator.SetTrigger(CUT);
    }

}