using DevExpress.Xpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E2042
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.SetNewData();
            this.ChangeItem = new DelegateCommand(this.ChangeItemExecute);
            this.ChangeSource = new DelegateCommand(this.ChangeSourceExecute);
            this.DeleteItem = new DelegateCommand(this.DeleteItemExecute);
            this.AddNewItem = new DelegateCommand(this.AddNewItemExecute);
        }

        private ObservableCollection<Task> _List;
        public ObservableCollection<Task> List
        {
            get
            {
                return _List;
            }

            set
            {
                if(this._List != value) {
                    this._List = value;
                    this.OnPropertyChanged("List");
                }
                
            }
        }

        public ICommand ChangeSource { get; set; }
        public ICommand AddNewItem { get; set; }
        public ICommand DeleteItem { get; set; }
        public ICommand ChangeItem { get; set; }

        protected void ChangeSourceExecute() {
            this.SetNewData();
        }

        protected void AddNewItemExecute() {
            if(this.List != null) {
                this.List.Add(new Task() { Num = 0, Name = "Additional New Item" });
            }
            
        }

        protected void DeleteItemExecute() {
            if(this.List != null && this.List.Count > 0) {
                this.List.RemoveAt(this.List.Count - 1);
            }
        }

        protected void ChangeItemExecute() {
            if(this.List != null && this.List.Count > 0) {
                this.List[0].Num = 1000000000;
            }
        }

        protected void SetNewData() {
            if(this.List == null) {
                List = new ObservableCollection<Task>();
            } else {
                this.List.Clear();
            }
            for(int i = 0; i < 20; i++) {
                List.Add(new Task() { Num = i, Name = "Name " + i * (i + 10), IsCompleted = i % 2 == 0 });
            }
        }



        public void OnPropertyChanged(string info) {
            if(this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
