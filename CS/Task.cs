using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace E2042 {
    public class Task : INotifyPropertyChanged {
        private int _Num;
        private string _Name;
        private bool _IsCompleted;

        public int Num {
            get {
                return _Num;
            }
            set {
                _Num = value;
                NotifyPropertyChanged("Num");
            }
        }


        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public bool IsCompleted {
            get {
                return _IsCompleted;
            }
            set {
                _IsCompleted = value;
                NotifyPropertyChanged("IsCompleted");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
