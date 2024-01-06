using UnityEngine;

public class TrueTransition : StateTransition
{
    public override bool MakeCondition()
    {
        return true;
    }
}
