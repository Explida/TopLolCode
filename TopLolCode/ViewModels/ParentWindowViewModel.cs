using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using TopLolCode.Models;

namespace TopLolCode.ViewModels
{
    public class ParentWindowViewModel: INotifyPropertyChanged
    {
        private Data _data;

        public int TimedShutdown
        {
            get { return _data.TimedShutdown; }
            set { _data.TimedShutdown = value; }
        }
        public bool TestMode
        {
            get { return _data.TestMode; }
            set { _data.TestMode = value; }
        }
        public bool FullScreen
        {
            get { return _data.FullScreen; }
            set { _data.FullScreen = value; }
        }
        public bool BlockKeys
        {
            get { return _data.BlockKeys; }
            set { _data.BlockKeys = value; }
        }
        public string SelectedLang
        {
            get { return _data.SelectedLang; }
            set { _data.SelectedLang = value; }
        }

        public string ID { get => _ID; set => _ID = value; }
        //public string Access { get => _access; set => _access = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public int DurationTime { get => _durationTime; set => _durationTime = value; }
        public List<DayOfWeek> Days { get => _days; set => _days = value; }

        public List<UserType> _regulat { get { return _data.Regulations; } }

        public Command SaveReg { get => _saveReg; set => _saveReg = value; }
        public Command DelReg { get => _delReg; set => _delReg = value; }
        public Command ToogleDays { get { return _toogleDays; } set { _toogleDays = value; } }

        private string _ID;
        private string _access = "Child";
        private DateTime _startDate;
        private DateTime _endDate;
        private int _durationTime;
        private List<DayOfWeek> _days;

        private Command _saveReg;
        private Command _delReg;
        private Command _toogleDays;



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        public ParentWindowViewModel()
        {
            _data = Data.GetSingleData();
            _days = new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday};

            _saveReg = new Command(SaveRegular, CanExecute);
            _delReg = new Command(DelRegular, CanExecute);
            _toogleDays = new Command(ToogleDaysM, CanExecute);
        }

        private void DelRegular(object param)
        {
            var t = (UserType)param;
            _data.RemoveRegulations(t.ID);
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
        }

        private void ToogleDaysM(object param)
        {
            var a = (ToggleButton)param;
            var day = a.Name.Remove(0, 1);
            DayOfWeek d = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day);
            if (a.IsChecked == true) _days.Add(d);
            if (a.IsChecked == false) _days.Remove(d);
        }
        
        private bool CanExecute(object param) { return true; }
    }
}
