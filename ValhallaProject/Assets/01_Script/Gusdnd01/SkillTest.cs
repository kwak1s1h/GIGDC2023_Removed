using UnityEngine;

public class SkillTest : SkillBase
{
    protected override void Reset()
    {
        skillIndex = 1;
    }

    public override void Skill()
    {
        if(!isLocked){
            Debug.Log("Skill Active");
            //스킬 내용 구성 적어주고
            btn.interactable = true;
        }
        else{
            Debug.Log("Skill Deactive");
            btn.interactable = false;
        }
    }
}
