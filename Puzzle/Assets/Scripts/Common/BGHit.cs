using UnityEngine;
using System.Collections;

public class BGHit : MonoBehaviour 
{
	public static string m_selectedObj_1 = "" , m_selectedObj_2 = "" ;
	

	/// <summary>
	/// Raises the mouse down event,
	/// When background is hited. 
	/// </summary>
	void OnMouseDown () 
	{
		BroadcastMessage ( "ReleaseObjects" ) ;
	}

}
