using System;
using System.Windows.Input;

namespace WpfApplication1
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute = true)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}

/*public class ObservableObject : INotifyPropertyChanged
{
public event PropertyChangedEventHandler PropertyChanged;

protected virtual void SetAndNotify<T>(ref T field, T value, Expression<Func<T>> property)
{
    if (!object.ReferenceEquals(field, value))
    {
        field = value;
        this.OnPropertyChanged(property);
    }
}

protected virtual void OnPropertyChanged<T>(Expression<Func<T>> changedProperty)
{
    if (PropertyChanged != null)
    {
        string name = ((MemberExpression)changedProperty.Body).Member.Name;
        PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}
Example use in ViewModel:
public string Name
{
    get { return this.name; }
    set { this.SetAndNotify(ref this.name, value, () => this.Name); }
}

*/
