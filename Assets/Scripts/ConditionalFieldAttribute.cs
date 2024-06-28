using UnityEngine;

public class ConditionalFieldAttribute : PropertyAttribute
{
    public string ConditionFieldName { get; private set; }
    public bool Inverse { get; private set; }

    public ConditionalFieldAttribute(string conditionFieldName, bool inverse = false)
    {
        ConditionFieldName = conditionFieldName;
        Inverse = inverse;
    }
}
