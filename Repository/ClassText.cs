namespace Repository
{
    public class ClassText : ClassNotify
    {
        private string _fishText;

        public ClassText()
        {
            // Initialize private variables
            _fishText = "Encrypto-Shiba Inc.\nWe Encrypt YOUR $H!7, so you don't have to B)";
        }

        // Declare properties
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

        // Overrides the ToString() method to return the fishText property
        public override string ToString()
        {
            return fishText;
        }

    }
}
