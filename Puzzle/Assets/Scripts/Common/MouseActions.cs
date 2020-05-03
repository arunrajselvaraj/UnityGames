using UnityEngine;
using System.Collections;

public class MouseActions : MonoBehaviour 
{
	public bool m_canMove = false   ;
	public string m_ObjName = "" ;

	void Awake () 
	{
		m_ObjName = this.gameObject.name ;
	}
	
	void Update ()
	{
		if( m_canMove && m_ObjName == this.gameObject.name  )
			{
				DragObject() ;
				
				BGHit.m_selectedObj_1 = m_ObjName ;
				
				if( Input.GetMouseButtonDown (1) )
				{
					transform.Rotate( 0, 0, 90 ) ;
				}
			}
	}
	
	/// <summary>
	/// Drags the object along mouse
	/// </summary>
	private void DragObject () 
	{
		gameObject.GetComponent<BoxCollider2D>().enabled = false ;
	
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = gameObject.transform.position.z;
		gameObject.transform.position = pos;	
	}
	
	void OnMouseDown()
	{
		if( BGHit.m_selectedObj_1 == "" )
		{
			m_canMove = true ;
			Log.InConsole( " PIECE PICKED ->>  " + m_ObjName , Log.E_Level.E_High ) ;
		}
		else
		{
			SwapObject () ;
		}
	}
	
	/// <summary>
	/// Releases the Selected object.
	/// When mouse point touch the Background 
	/// </summary>
	public void ReleaseObjects() 
	{
		ResetObj ()  ;
	}	
	
	private void ResetObj () 
	{
		m_canMove = false ;
		BGHit.m_selectedObj_1 = "" ;
		gameObject.GetComponent<BoxCollider2D>().enabled = true ;
		
		Log.InConsole( " PIECE DROPPED ->>  " + m_ObjName , Log.E_Level.E_High ) ;
	}
	
	
	/// <summary>
	/// Swaps the current selected object,
	/// with newly selected object
	/// </summary>
	private void SwapObject () 
	{
		BGHit.m_selectedObj_2 = m_ObjName ;
		
		Transform obj1 = GameObject.Find ( BGHit.m_selectedObj_1).transform ;
		Vector3 pos1 = obj1.position ; 
		Quaternion rot1 = obj1.rotation ;
		
		Transform obj2 = GameObject.Find ( BGHit.m_selectedObj_2).transform ;
		Vector3 pos2 = obj2.position ; 
		Quaternion rot2 = obj2.rotation ;
		
		obj1.transform.position = pos2 ;
		obj1.transform.rotation = rot2 ;
		
		obj2.transform.position = pos1 ;
		obj2.transform.rotation = rot1 ;
		
		obj1.GetComponent<MouseActions>().ReleaseObjects () ;
		
		m_canMove = true ;
		BGHit.m_selectedObj_1 = BGHit.m_selectedObj_2 ;
		BGHit.m_selectedObj_2 = "" ;
	}
}
