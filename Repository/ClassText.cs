namespace Repository
{
    public class ClassText : ClassNotify
    {
        private string _fishText;

        public ClassText()
        {
            _fishText = "FootKnight";
        }

        public string fishText
        {
            get { return _fishText; }
            set
            {
                if (_fishText != value)
                {
                    _fishText = value;
                }
                Notify("fishText");
            }
        }

        public override string ToString()
        {
            return fishText;
        }

    }
}
