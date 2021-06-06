using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratePlayfield : MonoBehaviour
{
    public GameObject playfieldObject;
    public GameObject starPefab, boundsPrefab, circleObstaclePrefab, squareObstaclePrefab, triangleObstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {   
        playfieldObject.GetComponent<Transform>().localScale = new Vector3(GAME_CONFIG.DEFAULT_WIDTH + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS, GAME_CONFIG.DEFAULT_HEIGHT + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS, 0);
        CreateBackgroundBounds();
        CreateBackgroundStars();
        CreateGameObstacles();
        gameObject.GetComponentInChildren<NavMeshSurface2d>().BuildNavMesh();
    }

    void CreateBackgroundBounds()
    {
        GameObject leftWall = CreateBoundsWall(GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.DEFAULT_HEIGHT + GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, -GAME_CONFIG.DEFAULT_WIDTH/2, 0);
        GameObject upWall = CreateBoundsWall(GAME_CONFIG.DEFAULT_WIDTH +GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, 0, GAME_CONFIG.DEFAULT_HEIGHT/2);
        GameObject rightWall = CreateBoundsWall(GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.DEFAULT_HEIGHT+GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.DEFAULT_WIDTH/2, 0);
        GameObject downWall = CreateBoundsWall(GAME_CONFIG.DEFAULT_WIDTH+GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, GAME_CONFIG.LEVEL_BOUNDS_THICKNESS, 0, -GAME_CONFIG.DEFAULT_HEIGHT/2);
    }

    GameObject CreateBoundsWall(float width, float height, float x, float y)
    {
        GameObject wall = Instantiate(boundsPrefab);
        wall.transform.localScale = new Vector3(width, height, 0);
        wall.transform.position = new Vector3(x, y, -2);
        return wall;
    }

    void CreateGameObstacles()
    {
        for (int i = 0; i < GAME_CONFIG.DEFAULT_WIDTH; i += GAME_CONFIG.OBSTACLE_DISTANCE)
        {
            for (int j = 0; j < GAME_CONFIG.DEFAULT_HEIGHT; j += GAME_CONFIG.OBSTACLE_DISTANCE)
            {
                bool skip = Random.Range(0, GAME_CONFIG.OBSTACLE_CHANCE) == 0 ? false : true;
                if (skip) continue;

                float x = -(GAME_CONFIG.DEFAULT_WIDTH / 2) + i + Random.Range(0, GAME_CONFIG.OBSTACLE_DISTANCE_INTERVAL);
                float y = -(GAME_CONFIG.DEFAULT_HEIGHT / 2) + j + Random.Range(0, GAME_CONFIG.OBSTACLE_DISTANCE_INTERVAL);

                CreateObstacle(x, y);
            }
        }
    }

    void CreateObstacle(float x, float y)
    {
        int select = Random.Range(0, 3);
        switch (select)
        {
            case 0:
                CreateACircle(x, y);
                break;
            case 1:
                CreateASquare(x, y);
                break;
            case 2:
                CreateATriangle(x, y);
                break;
        }
    }

    void CreateACircle(float x, float y)
    {
        // Simple circles of different sizes
        GameObject newObstacle = Instantiate(circleObstaclePrefab);
        newObstacle.transform.parent = gameObject.transform;
        newObstacle.transform.position = new Vector3(x, y, -2);
    }

    void CreateASquare(float x, float y)
    {
        // Randomly combine multiple squares
        GameObject newObstacle = Instantiate(squareObstaclePrefab);
        newObstacle.transform.parent = gameObject.transform;
        newObstacle.transform.position = new Vector3(x, y, -2);
    }

    void CreateATriangle(float x, float y)
    {
        // Randomly combine multiple triangles
        GameObject newObstacle = Instantiate(triangleObstaclePrefab);
        newObstacle.transform.parent = gameObject.transform;
        newObstacle.transform.position = new Vector3(x, y, -2);
    }

    void CreateBackgroundStars()
    {
        for (int i = 0; i < GAME_CONFIG.DEFAULT_WIDTH + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS; i += GAME_CONFIG.STARS_DISTANCE)
        {
            for (int j = 0; j < GAME_CONFIG.DEFAULT_HEIGHT + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS; j += GAME_CONFIG.STARS_DISTANCE)
            {
                bool skip = Random.Range(0, GAME_CONFIG.STAR_CHANCE) == 0 ? false : true;
                if (skip) continue;

                GameObject newStar = Instantiate(starPefab);
                newStar.transform.parent = playfieldObject.transform;

                float x = -(GAME_CONFIG.DEFAULT_WIDTH / 2 + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS/2 ) + i + Random.Range(0, GAME_CONFIG.STARS_DISTANCE_INTERVAL);
                float y = -(GAME_CONFIG.DEFAULT_HEIGHT / 2 + GAME_CONFIG.RENDER_OUTSIDE_BOUNDS / 2) + j + Random.Range(0, GAME_CONFIG.STARS_DISTANCE_INTERVAL);

                newStar.transform.position = new Vector3(x, y, 1);

                float size = Random.Range(0, GAME_CONFIG.AMOUNT_OF_STAR_SIZES);
                newStar.transform.localScale = new Vector3(GAME_CONFIG.STAR_START_SIZE + (GAME_CONFIG.STAR_EXTEND_SIZE*size), GAME_CONFIG.STAR_START_SIZE + (GAME_CONFIG.STAR_EXTEND_SIZE * size), 0);
            }
        }
    }
}
