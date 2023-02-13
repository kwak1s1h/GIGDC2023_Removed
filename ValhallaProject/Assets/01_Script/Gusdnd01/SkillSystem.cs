using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    [Range(0, 10)]
    public int index;
    public List<SkillBase> skills;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            skills[index].Skill();
        }
    }
}
