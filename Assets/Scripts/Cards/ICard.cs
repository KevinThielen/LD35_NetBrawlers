using UnityEngine;
using System.Collections.Generic;


public enum EForm {
	NONE,
	YELLOW,
	RED,
	GREEN,
	GRAY
}

public class ICard{
	string name = "Unknown Card";
	int cost = 0;
	EForm requiredForm;
	EForm shiftsInto;
	string description;
	List<System.Func<IAction>> actions = new List<System.Func<IAction>>();
	
	public string Name {
		get { return name; }
	}
	
	public string Description {
		get { return description; }
		set { description = value;}
	}
	public int Cost {
		get { return cost; }
	}
	
	public EForm RequiredForm {
		get { return requiredForm; }
	}
	
	public EForm ShiftsInto {
		get { return shiftsInto; }
	}
	public ICard(string name, int cost, EForm requiredForm, EForm shiftsInto) {
		this.name = name;
        this.cost = cost;
		this.requiredForm = requiredForm;
		this.shiftsInto = shiftsInto;
	}
	
	public void addAction(System.Func<IAction> action) {
	 	actions.Add(action);
	}
	
	public List<IAction> Actions() {
		List<IAction> executedActions = new List<IAction>();
		//foreach(System.Func<IAction> action in actions) {
		for(int i = actions.Count - 1; i>=0; i--) {
			executedActions.Add(actions[i]());
		}
		
		return executedActions;
	}
}
