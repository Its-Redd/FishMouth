using System.ComponentModel;

//using System.ComponentModel;

namespace Repository
{
    public class ClassNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ClassNotify()
        {

        }

        /// <summary>
        /// Notifies the GUI that a property has changed
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
