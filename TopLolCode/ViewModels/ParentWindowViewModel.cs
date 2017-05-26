using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using TopLolCode.Models;
using TopLolCode.Views;

namespace TopLolCode.ViewModels
{
    public class ParentWindowViewModel 
    {
        private Data _data;


        public string ID { get => _ID; set { _ID = value; } }
        //public string Access { get => _access; set => _access = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public int DurationTime { get => _durationTime; set => _durationTime = value; }
        //public ObservableCollection<DayOfWeek> Days { get => _days; set => _days = value; }

        public ObservableCollection<UserType> Regulat { get { return _data.Regulations;}}

        
        private string _ID;
        private string _access = "Child";
        private DateTime _startDate;
        private DateTime _endDate;
        private int _durationTime;
        private ObservableCollection<DayOfWeek> _days;

        public Command CommandSaveReg { get => _commandSaveReg  ; set => _commandSaveReg = value; }
        public Command CommandDelReg { get => _commandDelReg; set => _commandDelReg = value; }
        public Command CommandSettings { get => _commandSettings; set => _commandSettings = value; }
        public Command CommandToogleDays { get { return _commandToogleDays; } set { _commandToogleDays = value; } }

        private Command _commandSaveReg;
        private Command _commandDelReg;
        private Command _commandSettings;
        private Command _commandToogleDays;
        



        public ParentWindowViewModel()
        {
            _data = Data.GetSingleData();
            _days = new ObservableCollection<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday};

            _commandSaveReg = new Command(SaveRegular, CanExecute);
            _commandDelReg = new Command(DelRegular, CanExecute);
            _commandSettings = new Command(Settings, CanExecute);
            _commandToogleDays = new Command(ToogleDays, CanExecute);
        }

        private void SaveRegular(object param)
        {
            if (_data.FindID(_ID)) return; // исключение: уже есть такой идентификатор

            _data.AddRegulations(
                _ID,
                _access,
                _startDate,
                _endDate,
                _durationTime,
                _days);

            _data.SerializeData();
        }

        private void DelRegular(object param)
        {
            var t = (UserType)param;
            _data.RemoveRegulations(t.ID);
            _data.SerializeData();
        }

        private void Settings(object param)
        {
            var window = new SettingsWindow();
            window.Show();

            foreach (var firstRunWindow in Application.Current.Windows)
            {
                if (firstRunWindow is ParentWindow)
                    (firstRunWindow as ParentWindow).Close();
            }
        }

        private void ToogleDays(object param)
        {
            var a = (ToggleButton)param;
            var day = a.Name.Remove(0, 1);
            DayOfWeek d = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day);
            if (a.IsChecked == true)
            {
                _days.Add(d);
            }
            if (a.IsChecked == false)
            {
                _days.Remove(d);
            }
        }
        
        private bool CanExecute(object param) { return true; }
    }
}
