using UnityEngine;

public class SkillTest_4 : SkillBase {
	protected override void Reset(){
		skillIndex = 0;
	}
 
	public override void Skill(){
		if(!isLocked){
			//스킬 내용 구성 적어주고
			btn.interactable = true;
		}
		else{
			btn.interactable = false;
		}
	}
}
