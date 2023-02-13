using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillBase : MonoBehaviour
{
    protected int skillIndex;
    protected string skillName;
    protected bool isLocked = true;
    protected Button btn;

    private void Awake() {
        btn = GetComponent<Button>();
    }

    protected abstract void Reset();

    public abstract void Skill();
}
