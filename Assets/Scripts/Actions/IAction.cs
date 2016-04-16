using UnityEngine;

public class IAction {

	protected string actionName = "Unnamed";
	protected bool finished = false;
	
	public bool Finished 
	{
		get { return finished; }
	}
	
	public virtual bool Execute(Game game) {
		Debug.LogError(actionName+" not implemented");
		return false;
	}
	
}
