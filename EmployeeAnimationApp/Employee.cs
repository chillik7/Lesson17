using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace EmployeeAnimationApp
{
    public class Employee : INotifyPropertyChanged
    {
        private bool _isProfileVisible;

        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public bool IsProfileVisible
        {
            get => _isProfileVisible;
            set
            {
                if (_isProfileVisible != value)
                {
                    _isProfileVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public Brush StatusBrush => IsAvailable ? Brushes.Green : Brushes.Red;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
