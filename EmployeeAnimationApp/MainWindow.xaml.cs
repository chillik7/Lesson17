using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace EmployeeAnimationApp
{
    public partial class MainWindow : Window
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee { Name = "Иван Иванов", IsAvailable = true },
            new Employee { Name = "Мария Петрова", IsAvailable = false },
            new Employee { Name = "Алексей Смирнов", IsAvailable = true }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = (Storyboard)this.Resources["FadeInAnimation"];
            sb.Begin(MainGrid);
        }

        private void SearchEmployees_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList.ItemsSource = null;
            EmployeeList.ItemsSource = _employees;

          
            var index = 0;
            var items = EmployeeList.ItemContainerGenerator.Items;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromMilliseconds(300);
            timer.Tick += (s, args) =>
            {
                if (index < items.Count)
                {
                    var container = EmployeeList.ItemContainerGenerator.ContainerFromIndex(index) as FrameworkElement;
                    if (container != null)
                    {
                        var border = FindChild<Border>(container);
                        if (border != null)
                        {
                            var sb = (Storyboard)this.Resources["FadeInAnimation"];
                            sb.Begin(border);
                        }
                    }
                    index++;
                }
                else
                {
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void ShowProfile_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var emp = button?.Tag as Employee;
            if (emp != null)
            {
                emp.IsProfileVisible = !emp.IsProfileVisible; 
            }
           
            var sb = (Storyboard)this.Resources["ScaleUpAnimation"];
            sb.Begin(button);
        }


        private static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t)
                    return t;
                var result = FindChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
