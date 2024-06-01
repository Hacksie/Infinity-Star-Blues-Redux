using UnityEngine;

namespace HackedDesign
{
    public class Game : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerController player;

        [Header("Data")]
        [SerializeField] private GameData gameData;
        [SerializeField] private Settings settings;   

        [Header("UI")]     
        [SerializeField] private UI.MainMenuPresenter mainMenuPanel;
        [SerializeField] private UI.PauseMenuPresenter pauseMenuPanel;

        private IState state = new EmptyState();

        public static Game Instance { get; private set; }

        public IState State
        {
            get
            {
                return this.state;
            }
            private set
            {
                if(this.state != null)
                {
                    this.state.End();
                }
                this.state = value;
                if(this.state != null)
                {
                    this.state.Begin();
                }
            }
        }   

        public PlayerController Player { get { return player; } private set { player = value; } }     

        Game()
        {
            Instance = this;
        }  

        void Awake() => CheckBindings();
        void Start() => Initialization();
        void Update() => state.Update();
        void FixedUpdate() => state.FixedUpdate();          

        //public void SetMainMenu() => State = new MainMenuState(mainMenuPanel);
        //public void SetPauseMenu() => State = new PauseMenuState(pauseMenuPanel);
        //public void SetLoading() => State = new LoadingState();
        public void SetPlaying() => State = new PlayingState(Player);        

        public void Quit()
        {
            Application.Quit();
        }  

        public void Reset()
        {
        }

        private void CheckBindings()
        {
        }

        private void Initialization()
        {
            Reset();
            SetPlaying();
        }        
    }
}