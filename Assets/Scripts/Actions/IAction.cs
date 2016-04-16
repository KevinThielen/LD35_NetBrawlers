using UnityEngine;

public class IAction {

	protected string actionName = "Unnamed";

	
	public virtual bool Execute(Game game) {
		Debug.LogError(actionName+" not implemented");
		return true;
	}
	
}
