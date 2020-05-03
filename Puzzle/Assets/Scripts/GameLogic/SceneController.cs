using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	private bool m_isPreview = true ;
	
	//[HideInInspector]
	public Vector3[] m_puzPos = new Vector3[16] ;
	
	public GameObject m_startBtn , m_transBG , m_puzzlerImage ,
					  m_infoText , m_winTxt ; 
	
	public SuffleController m_SuffleCtrl ;
	
	public GameObject[] m_puzzlePieces ;
	
	void Start ()
	{
	
	}
	
	
	/// <summary>
	/// Prepare game to start. 
	/// </summary>
	public void PreSetUp ()
	{
		m_startBtn.SetActive ( true ) ;
		m_transBG.SetActive ( true ) ;
		
		PuzzlePieceIOCtrl ( false ) ;
		m_infoText.SetActive (false ) ;
		m_winTxt.SetActive (false ) ;
		
		AssignPos () ;
	}
	
	public void StartGame () 
	{
		Log.InConsole( " START GAME - SETUP - START !! ", Log.E_Level.E_High ) ;
		
		SceneSetUp () ;
		SufflePieces () ;
		PuzzlePieceIOCtrl ( true ) ;
	}
	
	private void AssignPos () 
	{
		for ( int i = 0 ; i < m_puzzlePieces.Length ; i++ )
		{
			m_puzPos[i] = m_puzzlePieces[i].transform.position ;
		}
	}
	
	private void  SceneSetUp ()
	{
		m_startBtn.SetActive ( false ) ;
		m_transBG.SetActive ( false ) ;
		
		m_puzzlerImage.SetActive (false ) ;
	}
	
	private void SufflePieces()
	{
		m_SuffleCtrl.SufflePuzzlePieces () ;
	}
	
	/// <summary>
	/// Puzzles piece visiblity.
	/// </summary>
	/// <param name="state_">If set to <c>true</c> state_.</param>
	private void PuzzlePieceVisiblity ( bool state_ )
	{
		for ( int i = 0 ; i < m_puzzlePieces.Length ; i++ )
		{
			m_puzzlePieces[i].GetComponent<PiecesProperties>().PiecesIO( state_ ) ;
		}
	}
	
	/// <summary>
	/// Puzzles touch control
	/// </summary>
	/// <param name="state_">If set to <c>true</c> state_.</param>
	private void PuzzlePieceIOCtrl ( bool state_ )
	{
		for ( int i = 0 ; i < m_puzzlePieces.Length ; i++ )
		{
			m_puzzlePieces[i].GetComponent<PiecesProperties>().PiecesVisiblity( state_ ) ;
		}
	}
	
	/// <summary>
	/// Shows the previw of Puzzle image.
	/// </summary>
	public void ShowPreviwImage ()
	{
		if( m_isPreview )
		{
			m_isPreview = false ;
			m_puzzlerImage.SetActive (true ) ;
			PuzzlePieceIOCtrl (false ) ;
			m_infoText.SetActive ( true ) ;
		}
		else
		{
			m_isPreview = true ;
			m_puzzlerImage.SetActive (false ) ;
			PuzzlePieceIOCtrl (true ) ;
			m_infoText.SetActive ( false ) ;
		}
	}
	
	
	public void ShowWinScreen () 
	{
		StartCoroutine ( "ShowWinInDelay" ) ;
	}
	
	private IEnumerator ShowWinInDelay () 
	{
		yield return new WaitForSeconds (1f ) ;
		PuzzlePieceIOCtrl ( false ) ;
		//m_transBG.SetActive ( true ) ;
		m_puzzlerImage.SetActive (true ) ;
		m_winTxt.SetActive (true ) ;
	}
}
