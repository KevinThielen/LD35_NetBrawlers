using UnityEngine;
using System.Collections.Generic;

public class ICard{
	string name = "Unknown Card";
	
	
	List<System.Func<IAction>> actions = new List<System.Func<IAction>>();
	
	public string Name {
		get { return name; }
	}
	
	
	public ICard(string name) {
		this.name = name;

	}
	
	public void addAction(System.Func<IAction> action) {
	 	actions.Add(action);
	}
	
	public List<IAction> Actions() {
		List<IAction> executedActions = new List<IAction>();
		foreach(System.Func<IAction> action in actions) {
			executedActions.Add(action());
		}
		
		return executedActions;
	}
}
