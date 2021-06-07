using UnityEditor;
using UnityEngine;


public static class GAME_CONFIG
{
    // Configuration for level RENDERING
    public const int LEVEL_BOUNDS_THICKNESS = 3; // default == 3
    //public const int DEFAULT_WIDTH = 250; // default == 300, can't be lower than 200
    //public const int DEFAULT_HEIGHT = 250; // default == 300, can't be lower than 100
    public const int RENDER_OUTSIDE_BOUNDS = 222; // default == 222
    public const int STARS_DISTANCE = 30; // default == 30
    public const int STARS_DISTANCE_INTERVAL = 9; // default == 9
    public const int STAR_CHANCE = 3; // default == 3
    public const int AMOUNT_OF_STAR_SIZES = 30; // default == 30
    public const float STAR_START_SIZE = 0.0006f; // default == 0.0006f
    public const float STAR_EXTEND_SIZE = 0.00005f; // default == 0.00005f
    public const int OBSTACLE_DISTANCE = 60; // default == 60
    public const int OBSTACLE_CHANCE = 2; // default == 2
    public const int OBSTACLE_DISTANCE_INTERVAL = 9; // default == 9
    public const int MAX_COMBINED_OBSTACLES = 10; // default == 10


    public const float BULLET_TIME_ALIVE = 1f;








    // Setup variables from main-menu, also with defaults underlaid
    // ------------------------------------------------------------
    public static int LEVEL = 0;

    public static int max_enemies = 30;
    //public static int enemies_spawn_timer = 5;
    public static int max_power_ups = 30;
    //public static int power_up_spawn_timer = 1;
    //public static float enemy_shooting_speed = 1;

    // PLAYER defaults
    public static ShipStats playerShipSettings = new ShipStats(20, 20, 1, 33, 300, BulletType.Player, 5f, 5f);

    // ENEMIES defaults
    public static ShipStats enemiesShipSettings = new ShipStats(3, 3, 1, 25, 300, BulletType.Enemy, 5f, 5f);
    // ------------------------------------------------------------
}

public static class LevelConfiguration
{
    public static int enemiesToKill { get; set; } = 5;
    public static int enemiesSpawnTimer { get; set; } = 3;
    public static int powerUpSpawnTimer { get; set; } = 3;
    public static int enemiesShootingSpeed { get; set; } = 2;
    public static int playfieldWidth { get; set; } = 300;
    public static int playfieldHeight { get; set; } = 300;
}