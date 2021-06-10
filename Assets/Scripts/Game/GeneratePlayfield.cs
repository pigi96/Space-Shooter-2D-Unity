using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratePlayfield : MonoBehaviour
{
    public GameObject playfieldObject;
    public GameObject starPefab, boundsPrefab;
    public GameObject[] obstacles;
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        Random.InitState(GAME_CONFIG.LEVEL); // Use seed for levels
        playfieldObject.GetComponent<Transform>().localScale = new Vector3(LevelConfiguration.playfieldWidth + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS, LevelConfiguration.playfieldHeight + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS, 0);
        CreateBackgroundBounds();
        //CreateBackgroundStars();
        CreateGameObstacleBetterSmiley();
        //CreateGameObstacles();
        gameObject.GetComponentInChildren<NavMeshSurface2d>().BuildNavMesh();
        Random.InitState(System.Environment.TickCount); // Reset seed
    }

    void CreateBackgroundBounds()
    {
        GameObject leftWall = CreateBoundsWall(GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, LevelConfiguration.playfieldHeight + GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, -LevelConfiguration.playfieldWidth/2, 0);
        GameObject upWall = CreateBoundsWall(LevelConfiguration.playfieldWidth +GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, 0, LevelConfiguration.playfieldHeight/2);
        GameObject rightWall = CreateBoundsWall(GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, LevelConfiguration.playfieldHeight+GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, LevelConfiguration.playfieldWidth/2, 0);
        GameObject downWall = CreateBoundsWall(LevelConfiguration.playfieldWidth+GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, 0, -LevelConfiguration.playfieldHeight/2);
    }

    GameObject CreateBoundsWall(float width, float height, float x, float y)
    {
        GameObject wall = Instantiate(boundsPrefab);
        wall.transform.localScale = new Vector3(width, height, 0);
        wall.transform.position = new Vector3(x, y, -2);
        return wall;
    }

    int obstacleSize = 16;
    void CreateGameObstacleBetterSmiley()
    {
        // Create 2D playifield matrix with 0 = walkable area, 1 = obstacle area
        // Dont spawn obstacles for 2 units all around the playfield
        // 1 unit == 10m aka. size of each obstacle
        int[,] area = new int[LevelConfiguration.playfieldHeight / obstacleSize, LevelConfiguration.playfieldWidth / obstacleSize];
        for (int i = 2; i < area.GetLength(0) - 2; i++)
        {
            for (int j = 2; j < area.GetLength(1) - 2; j++)
            {
                // Player spawn area is at (0, 0) -> no obstacles around, please
                if ((i >= area.GetLength(0)/2 - 1 && i <= area.GetLength(0)/2 + 1) &&
                    j >= area.GetLength(0)/2 - 1 && j <= area.GetLength(0)/2 + 1)
                {
                    continue;
                }

                int newObstacle;
                if (area[i, j-1] == 1 || area[i-1, j] == 1)
                {
                    // If leftER/upper neighbour has an obstacle -> 70% chance to make this place an obstacle
                    newObstacle = Random.Range(0, 100) < 25 ? 1 : 0;
                    
                } else
                {
                    // Else it's only 30% chance
                    newObstacle = Random.Range(0, 100) < 12 ? 1 : 0;
                }
                area[i, j] = newObstacle;
            }
        }

        // Create obstacle on every 1 in area
        // Methods are seperated for more complex creation
        for (int i = 0; i < area.GetLength(0); i++)
        {
            for (int j = 0; j < area.GetLength(1); j++)
            {
                if (area[i, j] == 1)
                {
                    GameObject newObstacle = Instantiate(obstaclePrefab);
                    newObstacle.transform.parent = gameObject.transform;
                    newObstacle.transform.position = new Vector3(-LevelConfiguration.playfieldWidth/2 + (j* obstacleSize),
                        LevelConfiguration.playfieldHeight/2 - (i* obstacleSize),
                        0);
                }
            }
        }
    }

    void CreateGameObstacles()
    {
        for (int i = 0; i < LevelConfiguration.playfieldWidth; i += GAME_CONFIG.OBSTACLE_DISTANCE)
        {
            for (int j = 0; j < LevelConfiguration.playfieldHeight; j += GAME_CONFIG.OBSTACLE_DISTANCE)
            {
                bool skip = Random.Range(0, GAME_CONFIG.OBSTACLE_CHANCE) == 0 ? false : true;
                if (skip) continue;

                float x = -(LevelConfiguration.playfieldWidth / 2) + i + Random.Range(0, GAME_CONFIG.OBSTACLE_DISTANCE_INTERVAL);
                float y = -(LevelConfiguration.playfieldHeight / 2) + j + Random.Range(0, GAME_CONFIG.OBSTACLE_DISTANCE_INTERVAL);

                CreateObstacle(x, y);
            }
        }
    }

    void CreateObstacle(float x, float y)
    {
        int select = Random.Range(0, obstacles.Length);
        GameObject newObstacle = Instantiate(obstacles[select]);
        newObstacle.transform.parent = gameObject.transform;
        newObstacle.transform.position = new Vector3(x, y, 0);
    }

    void CreateBackgroundStars()
    {
        for (int i = 0; i < LevelConfiguration.playfieldWidth + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS; i += GAME_CONFIG.STARS_DISTANCE)
        {
            for (int j = 0; j < LevelConfiguration.playfieldHeight + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS; j += GAME_CONFIG.STARS_DISTANCE)
            {
                bool skip = Random.Range(0, GAME_CONFIG.STAR_CHANCE) == 0 ? false : true;
                if (skip) continue;

                GameObject newStar = Instantiate(starPefab);
                newStar.transform.parent = playfieldObject.transform;

                float x = -(LevelConfiguration.playfieldWidth / 2 + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS/2 ) + i + Random.Range(0, GAME_CONFIG.STARS_DISTANCE_INTERVAL);
                float y = -(LevelConfiguration.playfieldHeight / 2 + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS / 2) + j + Random.Range(0, GAME_CONFIG.STARS_DISTANCE_INTERVAL);

                newStar.transform.position = new Vector3(x, y, 1);

                float size = Random.Range(0, GAME_CONFIG.AMOUNT_OF_STAR_SIZES);
                newStar.transform.localScale = new Vector3(GAME_CONFIG.STAR_START_SIZE + (GAME_CONFIG.STAR_EXTEND_SIZE*size), GAME_CONFIG.STAR_START_SIZE + (GAME_CONFIG.STAR_EXTEND_SIZE * size), 0);
            }
        }
    }
}
