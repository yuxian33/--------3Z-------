using Library;
using CartoonMirDB;

namespace Server.DBModels
{
    [UserObject]
    public sealed class AuctionInfo : DBObject
    {
        [Association("Auctions")]
        public AccountInfo Account
        {
            get { return _Account; }
            set
            {
                if (_Account == value) return;

                var oldValue = _Account;
                _Account = value;

                OnChanged(oldValue, value, "Account");
            }
        }
        private AccountInfo _Account;

        [Association("Auction")]
        public UserItem Item
        {
            get { return _Item; }
            set
            {
                if (_Item == value) return;

                var oldValue = _Item;
                _Item = value;

                OnChanged(oldValue, value, "Item");
            }
        }
        private UserItem _Item;

        public CharacterInfo Character
        {
            get { return _Character; }
            set
            {
                if (_Character == value) return;

                var oldValue = _Character;
                _Character = value;

                OnChanged(oldValue, value, "Character");
            }
        }
        private CharacterInfo _Character;
        
        public int Price
        {
            get { return _Price; }
            set
            {
                if (_Price == value) return;

                var oldValue = _Price;
                _Price = value;

                OnChanged(oldValue, value, "Price");
            }
        }
        private int _Price;

        public CurrencyType PriceType
        {
            get
            {
                return _PriceType;
            }
            set
            {
                if (_PriceType == value)
                    return;
                CurrencyType priceType = _PriceType;
                _PriceType = value;
                OnChanged((object)priceType, (object)value, nameof(PriceType));
            }
        }
        private CurrencyType _PriceType;

        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message == value) return;

                var oldValue = _Message;
                _Message = value;

                OnChanged(oldValue, value, "Message");
            }
        }
        private string _Message;

        protected override void OnDeleted()
        {
            Account = null;
            Item = null;
            Character = null;

            base.OnDeleted();
        }


        public ClientMarketPlaceInfo ToClientInfo(AccountInfo account)
        {
            return new ClientMarketPlaceInfo
            {
                Index = Index,

                Item = Item?.ToClientInfo(),

                Seller = Character?.CharacterName,

                Message = Message,

                IsOwner = account == Account,

                Price = Price,

                PriceType = PriceType
            };
        }



        public override string ToString()
        {
            return Account?.ToString() ?? string.Empty;
        }
    }
}
