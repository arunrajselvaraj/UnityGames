using UnityEngine;
using System.Collections;

public class IdentifyName : MonoBehaviour 
{
	private bool m_stopRay = false ;
	public string m_ObjName = "" , m_PuzzleName = "0" ;
	
	/// <summary>
	/// Project ray from object, to identify the 
	/// object placed above the template. 
	/// </summary>
	void Update () 
	{
		if( !m_stopRay )
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
			
			if ( hit.collider != null && this.transform.rotation == Quaternion.identity 
			    && hit.collider.tag == "PuzzlePieces" ) 
			{
				m_PuzzleName = hit.collider.name ; 
				//Log.InConsole( " RAY HITED TO ->>  " + hit.collider.name , Log.E_Level.E_High ) ;
			}
		}	
	}
	
	public void StopRayCast () 
	{
		m_stopRay = true ;
	}
}
