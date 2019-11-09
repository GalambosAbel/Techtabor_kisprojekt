using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeGrid : MonoBehaviour
{
	public string gridSize;
	public bool displayGridGizmos;
	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	public static NodeGrid instance;

	void Awake()
	{
		//gridWorldSize = new Vector2(Screen.width, Screen.height);
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
		//CreateGrid();
		gridSize = gridSizeX + " * " + gridSizeY;
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.LogError("there are 2 nodegrids");
		}
	}

	public int MaxSize
	{
		get
		{
			return gridSizeX * gridSizeY;
		}
	}

	public Vector2 SelfPos2D
	{
		get
		{
			return new Vector2(transform.position.x, transform.position.y);
		}
	}

	public void CreateGrid()
	{
		grid = new Node[gridSizeX,gridSizeY];
		Vector2 worldBottomLeft = SelfPos2D - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;
		for (int x = 0; x < gridSizeX; x ++)
		{
			for (int y = 0; y < gridSizeY; y ++)
			{
				Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
				grid[x,y] = new Node(!IsObsatclePresent(worldPoint),worldPoint, x,y);
			}
		}
	}

	bool IsObsatclePresent (Vector2 worldPoint)
	{
		Collider2D collider = null;
		collider = Physics2D.OverlapArea(worldPoint - new Vector2(nodeDiameter, nodeDiameter), worldPoint + new Vector2(nodeDiameter, nodeDiameter), unwalkableMask);
		if (collider == null) return false;
		return true;
	}

	public List<Node> GetNeighbours(Node node)
	{
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				if (x == 0 && y == 0) continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
				{
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}
		return neighbours;
	}
	

	public Node NodeFromWorldPoint(Vector3 worldPosition)
	{
		float percentX = (worldPosition.x + gridWorldSize.x / 2 - transform.position.x) / gridWorldSize.x;
		float percentY = (worldPosition.y + gridWorldSize.y / 2 - transform.position.y) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
		return grid[x,y];
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,gridWorldSize.y, 1));

		if (grid != null && displayGridGizmos)
		{
			foreach (Node n in grid)
			{
				Gizmos.color = (n.walkable) ? Color.green : Color.red;
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.5f));
			}
		}
	}
}