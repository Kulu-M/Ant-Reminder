using System.Windows;
using System.Windows.Input;

namespace Time_V_5
{
    /// <summary>
    /// Closes the current window.
    /// </summary>
    public class CloseWindowCommand : CommandBase<CloseWindowCommand>
    {
        public override void Execute(object parameter)
        {
            //Real Close of whole App
            App.closeApplicationMethod();

            //GetTaskbarWindow(parameter).Close();
            //CommandManager.InvalidateRequerySuggested();
        }


        public override bool CanExecute(object parameter)
        {
            Window win = GetTaskbarWindow(parameter);
            return win != null;
        }
    }
}