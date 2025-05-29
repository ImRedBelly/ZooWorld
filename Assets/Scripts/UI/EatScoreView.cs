using Systems;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class EatScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text preyScoreText;
        [SerializeField] private TMP_Text predatorScoreText;

        private IEatScoreService _eatScoreService;

        [Inject]
        public void Construct(IEatScoreService eatScoreService)
        {
            _eatScoreService = eatScoreService;

            _eatScoreService.UpdatePreyDead += UpdatePreyDead;
            _eatScoreService.UpdatePredatorDead += UpdatePredatorDead;

            UpdatePreyDead();
            UpdatePredatorDead();
        }

        private void OnDestroy()
        {
            _eatScoreService.UpdatePreyDead -= UpdatePreyDead;
            _eatScoreService.UpdatePredatorDead -= UpdatePredatorDead;
        }

        private void UpdatePreyDead()
        {
            preyScoreText.SetText(_eatScoreService.PreyDead.ToString());
        }

        private void UpdatePredatorDead()
        {
            predatorScoreText.SetText(_eatScoreService.PredatorDead.ToString());
        }
    }
}