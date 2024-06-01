namespace HackedDesign
{
    public class PlayingState : IState
    {
        PlayerController player;

        public PlayingState(PlayerController player)
        {
            this.player = player;
        }

        public bool Playing => true;

        public void Begin()
        {
            
        }

        public void End()
        {
            
        }

        public void Update()
        {
            this.player.UpdateBehaviour();
        }        

        public void FixedUpdate()
        {
            this.player.FixedUpdateBehaviour();
        }

        public void Menu()
        {
            
        }

        public void Select()
        {
            
        }


    }

}