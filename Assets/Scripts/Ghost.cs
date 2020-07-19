using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float moveSpeed = 5.9f;
    public float normalMoveSpeed = 5.9f;
    public float frightenedModeMoveSpeed = 2.9f;
    public float consumedSpeed = 15f;

    public bool canMove = true;

    public int pinkyReleaseTimer = 5;
    public int inkyReleaseTimer = 14;
    public int clydeReleaseTimer = 21;
    public float ghostReleaseTimer = 0;

    public int frightenedModeDurarion = 10;
    public int startBlinkingAt = 7;

    public bool isInGhostHoose = false;

    public Node startingPosition;
    public Node homeNode;
    public Node ghostHouse;

    public int scatterModeTimer1 = 7;
    public int chaseModeTimer1 = 20;
    public int scatterModeTimer2 = 7;
    public int chaseModeTimer2 = 20;
    public int scatterModeTimer3 = 5;
    public int chaseModeTimer3 = 20;
    public int scatterModeTimer4 = 5;

    public Sprite eyesUp;
    public Sprite eyesDown;
    public Sprite eyesLeft;
    public Sprite eyesRight;

    public RuntimeAnimatorController ghostUp;
    public RuntimeAnimatorController ghostDown;
    public RuntimeAnimatorController ghostLeft;
    public RuntimeAnimatorController ghostRight;

    public RuntimeAnimatorController ghostWhite;
    public RuntimeAnimatorController ghostBlue;

    private int modeChangeIteration = 1;
    private float modeChangeTimer = 0;

    private float frightenedModeTimer = 0;
    private float blinkTimer = 0;

    private bool frightenedModeIsWhite = false;

    private float previousMoveSoeed;

    private AudioSource backgroundAudio;

    public enum Mode
    {
        Chase,
        Scatter,
        Frightened,
        Consumed
    }

    Mode currentMode = Mode.Scatter;
    Mode previousMode;

    public enum GhostType
    {
        Red,
        Pink,
        Blue,
        Orange
    }

    public GhostType ghostType = GhostType.Red;

    private GameObject pacMan;

    private Node currentNode, targetNode, previousNode;
    private Vector2 direction, nextDirection;

    // Start is called before the first frame update
    void Start()
    {
        SpriteUpdate();

        if (GameBoard.isPlayerOneUp)
        {

            SetDifficultyForLevel(GameBoard.playerOneLevel);

        }
        else
        {

            SetDifficultyForLevel(GameBoard.playerTwoLevel);

        }

        backgroundAudio = GameObject.Find("Game").transform.GetComponent<AudioSource>();

        pacMan = GameObject.FindGameObjectWithTag("PacMan");

        Node node = GetNodeAtPosition(transform.localPosition);

        if (node != null)
        {
            currentNode = node;
        }

        if (isInGhostHoose)
        {
            direction = Vector2.up;
            targetNode = currentNode.neighbors[0];
        }
        else
        {
            direction = Vector2.left;
            targetNode = ChooseNextNode();
        }

        previousNode = currentNode;

        UpdateAnimation();
    }

    void SpriteUpdate()
    {
        if (OutFit.BlinkySprite != null)
        {
            GameObject blinky = GameObject.Find("ghost_Blinky");

            blinky.GetComponent<SpriteRenderer>().sprite = OutFit.BlinkySprite;

            blinky.GetComponent<Ghost>().ghostUp = OutFit.BlinkyUp;
            blinky.GetComponent<Ghost>().ghostDown = OutFit.BlinkyDown;
            blinky.GetComponent<Ghost>().ghostLeft = OutFit.BlinkyLeft;
            blinky.GetComponent<Ghost>().ghostRight = OutFit.BlinkyRight;

            blinky.GetComponent<SpriteRenderer>().sprite = OutFit.BlinkySprite;


            GameObject pinky = GameObject.Find("ghost_Pinky");

            pinky.GetComponent<SpriteRenderer>().sprite = OutFit.PinkySprite;

            pinky.GetComponent<Ghost>().ghostUp = OutFit.PinkyUp;
            pinky.GetComponent<Ghost>().ghostDown = OutFit.PinkyDown;
            pinky.GetComponent<Ghost>().ghostLeft = OutFit.PinkyLeft;
            pinky.GetComponent<Ghost>().ghostRight = OutFit.PinkyRight;

            pinky.GetComponent<SpriteRenderer>().sprite = OutFit.PinkySprite;


            GameObject inky = GameObject.Find("ghost_Inky");

            inky.GetComponent<SpriteRenderer>().sprite = OutFit.InkySprite;

            inky.GetComponent<Ghost>().ghostUp = OutFit.InkyUp;
            inky.GetComponent<Ghost>().ghostDown = OutFit.InkyDown;
            inky.GetComponent<Ghost>().ghostLeft = OutFit.InkyLeft;
            inky.GetComponent<Ghost>().ghostRight = OutFit.InkyRight;

            inky.GetComponent<SpriteRenderer>().sprite = OutFit.InkySprite;


            GameObject clyde = GameObject.Find("ghost_Clyde");

            clyde.GetComponent<SpriteRenderer>().sprite = OutFit.ClydeSprite;

            clyde.GetComponent<Ghost>().ghostUp = OutFit.ClydeUp;
            clyde.GetComponent<Ghost>().ghostDown = OutFit.ClydeDown;
            clyde.GetComponent<Ghost>().ghostLeft = OutFit.ClydeLeft;
            clyde.GetComponent<Ghost>().ghostRight = OutFit.ClydeRight;

            clyde.GetComponent<SpriteRenderer>().sprite = OutFit.ClydeSprite;
        }      
    }

    public void SetDifficultyForLevel(int level)
    {
        if(level == 1)
        {

            scatterModeTimer1 = 7;
            scatterModeTimer2 = 7;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 5;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 20;

            frightenedModeDurarion = 10;
            startBlinkingAt = 8;

            pinkyReleaseTimer = 5;
            inkyReleaseTimer = 14;
            clydeReleaseTimer = 21;

            moveSpeed = 5.9f;
            normalMoveSpeed = 5.9f;
            frightenedModeMoveSpeed = 2.9f;
            consumedSpeed = 16f;

        }
        else if (level == 2)
        {

            scatterModeTimer1 = 7;
            scatterModeTimer2 = 7;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1033;

            frightenedModeDurarion = 9;
            startBlinkingAt = 6;

            pinkyReleaseTimer = 4;
            inkyReleaseTimer = 12;
            clydeReleaseTimer = 18;

            moveSpeed = 6.9f;
            normalMoveSpeed = 6.9f;
            frightenedModeMoveSpeed = 3.9f;
            consumedSpeed = 18f;

        }
        else if (level == 3)
        {


            scatterModeTimer1 = 7;
            scatterModeTimer2 = 7;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1033;

            frightenedModeDurarion = 8;
            startBlinkingAt = 5;

            pinkyReleaseTimer = 3;
            inkyReleaseTimer = 10;
            clydeReleaseTimer = 15;

            moveSpeed = 7.9f;
            normalMoveSpeed = 7.9f;
            frightenedModeMoveSpeed = 4.9f;
            consumedSpeed = 20f;

        }
        else if (level == 4)
        {

            scatterModeTimer1 = 7;
            scatterModeTimer2 = 7;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1033;

            frightenedModeDurarion = 7;
            startBlinkingAt = 4;

            pinkyReleaseTimer = 2;
            inkyReleaseTimer = 8;
            clydeReleaseTimer = 13;

            moveSpeed = 8.9f;
            normalMoveSpeed = 8.9f;
            frightenedModeMoveSpeed = 5.9f;
            consumedSpeed = 22f;

        }
        else if (level == 5)
        {

            scatterModeTimer1 = 5;
            scatterModeTimer2 = 5;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 6;
            startBlinkingAt = 3;

            pinkyReleaseTimer = 2;
            inkyReleaseTimer = 6;
            clydeReleaseTimer = 10;

            moveSpeed = 9.9f;
            normalMoveSpeed = 9.9f;
            frightenedModeMoveSpeed = 6.9f;
            consumedSpeed = 24f;

        }
        else if (level > 5 && level <= 7)
        {
            scatterModeTimer1 = 3;
            scatterModeTimer2 = 3;
            scatterModeTimer3 = 3;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 6;
            startBlinkingAt = 3;

            pinkyReleaseTimer = 2;
            inkyReleaseTimer = 6;
            clydeReleaseTimer = 10;

            moveSpeed = 9.9f + level - 4;
            normalMoveSpeed = 9.9f + level - 4;
            frightenedModeMoveSpeed = 6.9f + level - 4;
            consumedSpeed = 24f + level - 3;

        }
        else if (level == 8)
        {

            scatterModeTimer1 = 5;
            scatterModeTimer2 = 5;
            scatterModeTimer3 = 5;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 5;
            startBlinkingAt = 1;

            pinkyReleaseTimer = 1;
            inkyReleaseTimer = 4;
            clydeReleaseTimer = 7;

            moveSpeed = 11.9f;
            normalMoveSpeed = 11.9f;
            frightenedModeMoveSpeed = 9.9f;
            consumedSpeed = 30f;

        }
        else if (level == 9)
        {

            scatterModeTimer1 = 4;
            scatterModeTimer2 = 4;
            scatterModeTimer3 = 4;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 4;
            startBlinkingAt = 1;

            pinkyReleaseTimer = 1;
            inkyReleaseTimer = 2;
            clydeReleaseTimer = 4;

            moveSpeed = 11.9f;
            normalMoveSpeed = 11.9f;
            frightenedModeMoveSpeed = 9.9f;
            consumedSpeed = 30f;

        }
        else if (level == 10)
        {

            scatterModeTimer1 = 2;
            scatterModeTimer2 = 2;
            scatterModeTimer3 = 2;
            scatterModeTimer4 = 1;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 3;
            startBlinkingAt = 1;

            pinkyReleaseTimer = 1;
            inkyReleaseTimer = 1;
            clydeReleaseTimer = 1;

            moveSpeed = 11.9f;
            normalMoveSpeed = 11.9f;
            frightenedModeMoveSpeed = 9.9f;
            consumedSpeed = 30f;

        }
        else if (level > 11) 
        {

            scatterModeTimer1 = 0;
            scatterModeTimer2 = 0;
            scatterModeTimer3 = 0;
            scatterModeTimer4 = 0;

            chaseModeTimer1 = 20;
            chaseModeTimer2 = 20;
            chaseModeTimer3 = 1037;

            frightenedModeDurarion = 2;
            startBlinkingAt = 1;

            pinkyReleaseTimer = 0;
            inkyReleaseTimer = 0;
            clydeReleaseTimer = 0;

            moveSpeed = 11.9f;
            normalMoveSpeed = 11.9f;
            frightenedModeMoveSpeed = 9.9f;
            consumedSpeed = 30f;

        }

    }

    public void MoveToStartingPosition()
    {
        if (transform.name != "ghost_Blinky")
        {
            isInGhostHoose = true;
        }

        transform.position = startingPosition.transform.position;

        if (isInGhostHoose)
        {

            direction = Vector2.up;

        }
        else
        {

            direction = Vector2.left;

        }

        UpdateAnimation();

    }

    public void Restart()
    {

        canMove = true;

        currentMode = Mode.Scatter;

        moveSpeed = normalMoveSpeed;

        previousMode = 0;



        ghostReleaseTimer = 0;
        modeChangeIteration = 1;
        modeChangeTimer = 0;

        if (transform.name != "ghost_Blinky")
        {
            isInGhostHoose = true;
        }

        currentNode = startingPosition;

        if (isInGhostHoose)
        {

            direction = Vector2.up;
            targetNode = currentNode.neighbors[0];

        }
        else
        {

            direction = Vector2.left;
            targetNode = ChooseNextNode();

        }

        previousNode = currentNode;

        UpdateAnimation();

    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {

            ModeUpdate();

            Move();

            ReleaseGhosts();

            CheckCollision();

            CheckIsInGhostHouse();
        }

    }

    void CheckIsInGhostHouse()
    {

        if (currentMode == Mode.Consumed)
        {

            GameObject tile = GetTileAtPosition(transform.position);

            if (tile != null)
            {

                if (tile.transform.GetComponent<Tile>() != null)
                {

                    if (tile.transform.GetComponent<Tile>().isGhostHouse)
                    {

                        moveSpeed = normalMoveSpeed;

                        Node node = GetNodeAtPosition(transform.position);

                        if (node != null)
                        {

                            currentNode = node;

                            direction = Vector2.up;
                            targetNode = currentNode.neighbors[0];

                            previousNode = currentNode;

                            currentMode = Mode.Chase;

                            UpdateAnimation();

                        }

                    }

                }

            }

        }

    }

    void CheckCollision()
    {

        Rect ghostRect = new Rect(transform.position, transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);
        Rect pacmanRect = new Rect(pacMan.transform.position, pacMan.transform.GetComponent<SpriteRenderer>().sprite.bounds.size / 4);

        if (ghostRect.Overlaps(pacmanRect))
        {
            if (currentMode == Mode.Frightened)
            {

                Consumed();

            }
            else 
            {
                if (currentMode != Mode.Consumed)
                {

                    GameObject.Find("Game").transform.GetComponent<GameBoard>().StartDeath();

                }

            }

        }

    }
    void Consumed()
    {

        if (GameMenu.isOnePlayerGame)
        {

            GameBoard.playerOneScore += GameBoard.ghostConsumedRunningScore;

        }
        else
        {

            if (GameObject.Find("Game").GetComponent<GameBoard>().playerOneUp)
            {
                GameBoard.playerOneScore += GameBoard.ghostConsumedRunningScore;
            }
            else
            {
                GameBoard.playerTwoScore += GameBoard.ghostConsumedRunningScore;
            }

        }

        currentMode = Mode.Consumed;
        previousMoveSoeed = moveSpeed;
        moveSpeed = consumedSpeed;

        UpdateAnimation();

        GameObject.Find("Game").transform.GetComponent<GameBoard>().StartConsumed(this.GetComponent<Ghost>());

        GameBoard.ghostConsumedRunningScore = GameBoard.ghostConsumedRunningScore * 2;

    }


    void UpdateAnimation()
    {
        if (currentMode != Mode.Frightened && currentMode != Mode.Consumed) 
        {

            if (direction == Vector2.up)
            {
                transform.GetComponent<Animator>().runtimeAnimatorController = ghostUp;

            }
            else if (direction == Vector2.down)
            {

                transform.GetComponent<Animator>().runtimeAnimatorController = ghostDown;

            }
            else if (direction == Vector2.left)
            {

                transform.GetComponent<Animator>().runtimeAnimatorController = ghostLeft;

            }
            else if (direction == Vector2.right)
            {

                transform.GetComponent<Animator>().runtimeAnimatorController = ghostRight;

            }
            else
            {
                transform.GetComponent<Animator>().runtimeAnimatorController = ghostLeft;
            }
        }
        else if(currentMode == Mode.Frightened)
        {

            transform.GetComponent<Animator>().runtimeAnimatorController = ghostBlue;

        }
        else if(currentMode == Mode.Consumed)
        {

            transform.GetComponent<Animator>().runtimeAnimatorController = null;

            if (direction == Vector2.up)
            {
                transform.GetComponent<SpriteRenderer>().sprite = eyesUp;

            }
            else if (direction == Vector2.down)
            {

                transform.GetComponent<SpriteRenderer>().sprite = eyesDown;

            }
            else if (direction == Vector2.left)
            {

                transform.GetComponent<SpriteRenderer>().sprite = eyesLeft;

            }
            else if (direction == Vector2.right)
            {

                transform.GetComponent<SpriteRenderer>().sprite = eyesRight;

            }
        }
    }

    private void Move()
    {
        if (targetNode != currentNode&& targetNode != null && !isInGhostHoose)
        {
            if (OverShotTarget())
            {
                currentNode = targetNode;

                transform.localPosition = currentNode.transform.position;

                GameObject otherPortal = GetPortal(currentNode.transform.position);

                if (otherPortal != null)
                {
                    transform.localPosition = otherPortal.transform.position;

                    currentNode = otherPortal.GetComponent<Node>();
                }

                targetNode = ChooseNextNode();

                previousNode = currentNode;

                currentNode = null;

                UpdateAnimation();
            }
            else
            {
                transform.localPosition += (Vector3)direction * moveSpeed * Time.deltaTime;
            }
        }
    }

    void ModeUpdate()
    {
        if(currentMode != Mode.Frightened)
        {
            modeChangeTimer += Time.deltaTime;

            if(modeChangeIteration == 1)
            {
                if(currentMode == Mode.Scatter&& modeChangeTimer > scatterModeTimer1)
                {
                    ChangeMode(Mode.Chase);
                    modeChangeTimer = 0;
                }

                if(currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer1)
                {
                    modeChangeIteration = 2;
                    ChangeMode(Mode.Scatter);
                    modeChangeTimer = 0;
                }

            }else if(modeChangeIteration == 2)
            {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer2)
                {
                    ChangeMode(Mode.Chase);
                    modeChangeTimer = 0;
                }

                if (currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer2)
                {
                    modeChangeIteration = 3;
                    ChangeMode(Mode.Scatter);
                    modeChangeTimer = 0;
                }

            }
            else if(modeChangeIteration == 3)
            {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer3)
                {
                    ChangeMode(Mode.Chase);
                    modeChangeTimer = 0;
                }

                if (currentMode == Mode.Chase && modeChangeTimer > chaseModeTimer3)
                {
                    modeChangeIteration = 4;
                    ChangeMode(Mode.Scatter);
                    modeChangeTimer = 0;
                }

            }
            else if(modeChangeIteration == 4)
            {

                if (currentMode == Mode.Scatter && modeChangeTimer > scatterModeTimer4)
                {
                    ChangeMode(Mode.Chase);
                    modeChangeTimer = 0;
                }

            }

        }else if(currentMode == Mode.Frightened)
        {

            frightenedModeTimer += Time.deltaTime;

            if(frightenedModeTimer>= frightenedModeDurarion)
            {

                backgroundAudio.clip = GameObject.Find("Game").transform.GetComponent<GameBoard>().backgroundAudioNormal;
                backgroundAudio.Play();

                frightenedModeTimer = 0;
                ChangeMode(previousMode);

            }

            if(frightenedModeTimer >= startBlinkingAt)
            {

                blinkTimer += Time.deltaTime;

                if (blinkTimer >= 0.1f)
                {

                    blinkTimer = 0f;

                    if (frightenedModeIsWhite)
                    {

                        transform.GetComponent<Animator>().runtimeAnimatorController = ghostBlue;
                        frightenedModeIsWhite = false;

                    }
                    else
                    {

                        transform.GetComponent<Animator>().runtimeAnimatorController = ghostWhite;
                        frightenedModeIsWhite = true;

                    }

                }

            }

        }
    }

    void ChangeMode(Mode m)
    { 

        if(currentMode == Mode.Frightened)
        {

            moveSpeed = previousMoveSoeed;

        }

        if(m == Mode.Frightened)
        {

            previousMoveSoeed = moveSpeed;
            moveSpeed = frightenedModeMoveSpeed;

        }

        if (currentMode != m)
        {

            previousMode = currentMode;
            currentMode = m;
        }

        UpdateAnimation();

    }

    public void StartFrightenedMode()
    {

        if (currentMode != Mode.Consumed)
        {

            GameBoard.ghostConsumedRunningScore = 200;

            frightenedModeTimer = 0;

            backgroundAudio.clip = GameObject.Find("Game").transform.GetComponent<GameBoard>().backgroundAudioFrightened;
            backgroundAudio.Play();

            ChangeMode(Mode.Frightened);

        }

    }

    Vector2 GetRedGhostTargetTile()
    {

        Vector2 pacmanPosition = pacMan.transform.position;
        Vector2 targetTile = new Vector2(Mathf.RoundToInt(pacmanPosition.x), Mathf.RoundToInt(pacmanPosition.y));

        return targetTile;
    }

    Vector2 GetPinkyGhostTargetTile()
    {

        // Four tile ahead
        Vector2 pacmanPosition = pacMan.transform.position;
        Vector2 pacManOrientation = pacMan.GetComponent<PacMan>().orientation;

        int pacManPositionX = Mathf.RoundToInt(pacmanPosition.x);
        int pacManPositionY = Mathf.RoundToInt(pacmanPosition.y);

        Vector2 pacManTile = new Vector2(pacManPositionX, pacManPositionY);
        Vector2 targetTile = pacManTile + (4 * pacManOrientation);

        return targetTile;

    }

    Vector2 GetTargetTile()
    {
        Vector2 targetTile = Vector2.zero;

        if (ghostType == GhostType.Red)
        {
            targetTile = GetRedGhostTargetTile();
        }
        else if (ghostType == GhostType.Pink)
        {
            targetTile = GetPinkyGhostTargetTile();

        }else if(ghostType == GhostType.Blue)
        {

            targetTile = GetBlueGhostTargetTile();

        }else if (ghostType == GhostType.Orange)
        {

            targetTile = GetOrangeGhostTargetTile();

        }
        return targetTile;
    }

    Vector2 GetRandomTile()
    {

        int x = Random.Range(0, 28);
        int y = Random.Range(0, 36);

        return new Vector2(x, y);

    }

    Vector2 GetBlueGhostTargetTile()
    {
        Vector2 pacManPosition = pacMan.transform.localPosition;
        Vector2 pacManOrientation = pacMan.GetComponent<PacMan>().orientation;

        int pacManPositionX = Mathf.RoundToInt(pacManPosition.x);
        int pacManPositionY = Mathf.RoundToInt(pacManPosition.y);

        Vector2 pacManTile = new Vector2(pacManPositionX, pacManPositionY);

        Vector2 targetTile = pacManTile + (2 * pacManOrientation);

        Vector2 tempBlinkyPosition = GameObject.Find("ghost_Blinky").transform.localPosition;

        int blinkyPositionX = Mathf.RoundToInt(tempBlinkyPosition.x);
        int blinkyPositionY = Mathf.RoundToInt(tempBlinkyPosition.y);

        tempBlinkyPosition = new Vector2(blinkyPositionX, blinkyPositionY);

        float distance = GetDistance(tempBlinkyPosition, targetTile);
        distance *= 2;

        targetTile = new Vector2(tempBlinkyPosition.x + distance, tempBlinkyPosition.y + distance);

        return targetTile;
    }

    Vector2 GetOrangeGhostTargetTile()
    {
        Vector2 pacManPosition = pacMan.transform.localPosition;

        float distance = GetDistance(transform.localPosition, pacManPosition);
        Vector2 targetTile = Vector2.zero;

        if (distance > 8)
        {

            targetTile = new Vector2(Mathf.RoundToInt(pacManPosition.x), Mathf.RoundToInt(pacManPosition.y));

        }else if (distance < 8)
        {

            targetTile = homeNode.transform.position;

        }

        return targetTile;
    }

    void ReleasePinkGhost()
    {
        if(ghostType==GhostType.Pink&& isInGhostHoose)
        {
            isInGhostHoose = false;
        }
    }

    void RealeaseBlueGhost()
    {

        if (ghostType == GhostType.Blue && isInGhostHoose)
        {
            isInGhostHoose = false;
        }

    }

    void RealeaseOrangeGhost()
    {

        if (ghostType == GhostType.Orange && isInGhostHoose)
        {
            isInGhostHoose = false;
        }

    }

    void ReleaseGhosts()
    {
        ghostReleaseTimer += Time.deltaTime;

        if (ghostReleaseTimer > pinkyReleaseTimer)
        {
            ReleasePinkGhost();
        }

        if (ghostReleaseTimer > inkyReleaseTimer)
        {
            RealeaseBlueGhost();
        }

        if (ghostReleaseTimer > clydeReleaseTimer)
        {
            RealeaseOrangeGhost();
        }
    }

    

    Node ChooseNextNode()
    {
        Vector2 targetTile = Vector2.zero;

        if (currentMode == Mode.Chase)
        {

            targetTile = GetTargetTile();

        }else if (currentMode == Mode.Scatter)
        {
            targetTile = homeNode.transform.position;
        }
        else if(currentMode == Mode.Frightened)
        {

            targetTile = homeNode.transform.position;

        }
        else if (currentMode == Mode.Consumed)
        {

            targetTile = ghostHouse.transform.position;

        }

        Node moveToNode = null;

        Node[] foundNodes = new Node[4];
        Vector2[] foundNodesDirection = new Vector2[4];

        int nodeCounter = 0;

        for (int i = 0; i < currentNode.neighbors.Length; i++)
        {
            if (currentNode.validDirections[i] != direction * -1)
            {
                if(currentMode != Mode.Consumed)
                {

                    GameObject tile = GetTileAtPosition(currentNode.transform.position);

                    if (tile.transform.GetComponent<Tile>().isGhostHouseEntrance == true)
                    {

                        if (currentNode.validDirections[i] != Vector2.down)
                        {

                            foundNodes[nodeCounter] = currentNode.neighbors[i];
                            foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                            nodeCounter++;

                        }

                    }
                    else
                    {

                        foundNodes[nodeCounter] = currentNode.neighbors[i];
                        foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                        nodeCounter++;

                    }

                }
                else
                {

                    foundNodes[nodeCounter] = currentNode.neighbors[i];
                    foundNodesDirection[nodeCounter] = currentNode.validDirections[i];
                    nodeCounter++;

                }
                
            }

        }

        if (foundNodes.Length == 1)
        {
            moveToNode = foundNodes[0];
            direction = foundNodesDirection[0];
        }

        if (foundNodes.Length > 1)
        {
            float leastDistance = 100000f;

            for( int i = 0; i < foundNodes.Length; i++)
            {
                if(foundNodesDirection[i]!= Vector2.zero)
                {
                    float distance = GetDistance(foundNodes[i].transform.localPosition, targetTile);

                    if (distance < leastDistance)
                    {
                        leastDistance = distance;
                        moveToNode = foundNodes[i];
                        direction = foundNodesDirection[i];
                    }
                }
            }
        }

        return moveToNode;
    }

    GameObject GetTileAtPosition(Vector2 pos)
    {
        int tileX = Mathf.RoundToInt(pos.x);
        int tileY = Mathf.RoundToInt(pos.y);

        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[tileX, tileY];

        if (tile != null)
        {

            return tile;

        }

        return null;
    }

    Node GetNodeAtPosition (Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y];

        if (tile != null)
        {
            if (tile.GetComponent<Node>() != null)
            {
                return tile.GetComponent<Node>();
            }
        }

        return null;
    }

    GameObject GetPortal(Vector2 pos)
    {
        GameObject tile = GameObject.Find("Game").GetComponent<GameBoard>().board[(int)pos.x, (int)pos.y];

        if (tile != null)
        {
            if (tile.GetComponent<Tile>().isPortal)
            {
                GameObject otherPortal = tile.GetComponent<Tile>().portalReceiver;
                return otherPortal;
            }
        }
        return null;
    }

    float LengthFromNode (Vector2 targetPosition)
    {
        Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;
        return vec.sqrMagnitude;
    }

    bool OverShotTarget()
    {
        float nodeToTarget = LengthFromNode(targetNode.transform.position);
        float nodeToSelf = LengthFromNode(transform.localPosition);

        return nodeToSelf > nodeToTarget;
    }

    float GetDistance (Vector2 posA, Vector2 posB)
    {
        float dx = posA.x - posB.x;
        float dy = posA.y - posB.y;

        float distance = Mathf.Sqrt(dx * dx + dy * dy);

        return distance;
    }
}
