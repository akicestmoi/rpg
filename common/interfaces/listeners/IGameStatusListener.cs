public interface IGameStatusListener {

    public void onGameStart();
    public void onPlayerTurn();
    public void onPlayerMove(IGameManager gameManager);
    public void onEnemyEncounter(IGameManager gameManager);
    public void onGameEnd();
}