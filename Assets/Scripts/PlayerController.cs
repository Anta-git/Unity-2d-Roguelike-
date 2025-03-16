using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private BoardManager m_BoardManager;
    private Vector2Int m_CellPosition;

    public void Spawn (BoardManager boardManager, Vector2Int cellPosition)
    {
        m_BoardManager = boardManager;
        m_CellPosition = cellPosition;

        MoveTo(m_CellPosition);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2Int newCellTarget = m_CellPosition;
        bool hasMoved = false;

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newCellTarget.y += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            newCellTarget.y -= 1;
            hasMoved = true;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newCellTarget.x += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newCellTarget.x -= 1;
            hasMoved = true;
        }

        if (hasMoved)
        {
            //check if the new position is passable, then move there if it is.
            BoardManager.CellData cellData = m_BoardManager.GetCellData(newCellTarget);

            if (cellData != null && cellData.isPassable)
            {
                GameManager.Instance.turnManager.Tick();
                MoveTo(newCellTarget);
            }
        }
    }

    public void MoveTo(Vector2Int cell)
    {
        m_CellPosition = cell;
        transform.position = m_BoardManager.CellToWorld(m_CellPosition);
    }
}
