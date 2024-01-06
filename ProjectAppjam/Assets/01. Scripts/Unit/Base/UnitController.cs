using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	[SerializeField] UnitDataSO unitData;
    public UnitDataSO UnitData => unitData;

    private Dictionary<UnitStateType, UnitState> states;
    private Dictionary<UnitComponentType, UnitComponent> components;

    [field:SerializeField]
    public UnitStateType CurrentStateType { get; private set; }
    public UnitState CurrentState => states[CurrentStateType];

    public Transform Target;
    public bool IsDead = false;

    public UnitAnimator Ainmator {get; private set;}

    private void Awake()
    {
        Ainmator = transform.Find("Visual").GetComponent<UnitAnimator>();
        
    }

    private void Start()
    {
        InitComponents();
        InitStates();

        ChangeState(UnitStateType.Idle);
    }

    private void Update()
    {
        CurrentState?.UpdateState();
    }

    public void ChangeState(UnitStateType type)
    {
        CurrentState?.ExitState();
        CurrentStateType = type;
        CurrentState?.EnterState();
    }

    public T GetUnitComponent<T>(UnitComponentType type) where T : UnitComponent
    {
        return components[type] as T;
    }

    public UnitState GetUnitState(UnitStateType stateType)
    {
        return states[stateType];
    }

    private void InitComponents()
    {
        this.components = new Dictionary<UnitComponentType, UnitComponent>();
        foreach(UnitComponentType type in Enum.GetValues(typeof(UnitComponentType)))
        {
            string typeName = $"Unit{type}";
            UnitComponent compo = transform.GetComponent(typeName) as UnitComponent;
            compo.Init(this);
            this.components.Add(type, compo);
        }
    }

    private void InitStates()
    {
        states = new Dictionary<UnitStateType, UnitState>();
        Transform stateContainer = transform.Find("StateContainer");

        foreach(UnitStateType type in Enum.GetValues(typeof(UnitStateType)))
        {
            string stateName = $"Unit{type}State";

            Transform stateTrm = stateContainer.Find(stateName);
            UnitState state = (UnitState)stateTrm?.GetComponent(stateName);

            if(state == null)
            {
                Debug.LogWarning($"State doesn't existed : {stateName}");
                continue;
            }

            state.Init(this, type);
            states.Add(type, state);
        }
    }

    public void DelayCallback(float delay, Action callback)
    {
        StartCoroutine(DelayCoroutine(delay, callback));
    }

    private IEnumerator DelayCoroutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
