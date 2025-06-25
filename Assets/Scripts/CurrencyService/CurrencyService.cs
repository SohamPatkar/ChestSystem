using ChestSystem.Main;

namespace ChestSystem.Currency
{
    public class CurrencyService
    {
        private int gems;
        private int coins;

        public CurrencyService()
        {
            Initialize();
        }

        public void Initialize()
        {
            gems = 0;
            coins = 0;
        }

        public int GetGems()
        {
            return gems;
        }

        public void AddGems(int addGems)
        {
            gems += addGems;
            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
        }

        public void SubtractGems(int subGems)
        {
            gems -= subGems;

            if (gems <= 0 || gems < subGems)
            {
                EventService.Instance.OnNotEnoughCoins.InvokeEvent();
                gems = 0;
            }

            EventService.Instance.OnUpdateGems.InvokeEvent(gems);
        }

        public void AddCoins(int addCoins)
        {
            coins += addCoins;
            EventService.Instance.OnUpdateCoins.InvokeEvent(coins);
        }
    }
}


