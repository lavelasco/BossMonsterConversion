using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IHasChanged : IEventSystemHandler
{
	void HasChanged();
}


public class Bins : MonoBehaviour, IHasChanged 
{
	[SerializeField] Transform slots;
	[SerializeField] Text binText;


	// Use this for initialization
	void Start () 
	{
		HasChanged ();
	}

	#region IHasChanged implementation
	public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
		builder.Append (" - ");
		foreach (Transform slotTransform in slots) 
		{
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if(item)
			{
				builder.Append(item.name);
				builder.Append (" - ");
			}
		}
		//binText.GetNativeTextureID() = builder.ToString ();
	#endregion
	}
}