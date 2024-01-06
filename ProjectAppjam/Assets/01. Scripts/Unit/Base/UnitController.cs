using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	[SerializeField] UnitDataSO unitData;
    public UnitDataSO UnitData => unitData;

    private Dictionary<UnitStateType, UnitState> states;
    private Dictionary<string, UnitComponent> components;

    [field:SerializeField]
    public UnitStateType CurrentStateType { get; private set; }
    public UnitState CurrentState => states[CurrentStateType];

    [field : SerializeField]
    public Transform Target { get; private set; }
    public bool IsDead = false;

    private void Awake()
    {
        InitComponents();
        InitStates();
    }

    private void Start()
    {
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

    public T GetUnitComponent<T>() where T : UnitComponent
    {
        return components[typeof(T).ToString()] as T;
    }

    public UnitState GetUnitState(UnitStateType stateType)
    {
        return states[stateType];
    }

    private void InitComponents()
    {
        List<UnitComponent> components = new List<UnitComponent>();
        transform.GetComponentsInChildren<UnitComponent>(components);

        this.components = new Dictionary<string, UnitComponent>();
        components.ForEach(compo => {
            compo.Init(this);
            this.components.Add(compo.GetType().ToString(), compo);
        });
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
