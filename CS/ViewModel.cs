using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;

namespace E2042 {
    public class ViewModel : ViewModelBase {
        public ViewModel() {
            SetNewData();
        }
        public ObservableCollection<Task> List { get; set; }
        public void SetNewData() {
            if (List == null) {
                List = new ObservableCollection<Task>();
            } else {
                List.Clear();
            }
            for (int i = 0; i < 20; i++) {
                List.Add(new Task() { Num = i, Name = "Name " + i * (i + 10), IsCompleted = i % 2 == 0 });
            }
        }

        [Command]
        public void ChangeSource() {
            SetNewData();
        }
        [Command]
        public void ChangeItem() {
            if (List != null && List.Count > 0) {
                List[0].Num = 1000000000;
            }
        }
        [Command]
        public void AddNewItem() {
            if (List != null) {
                List.Add(new Task() { Num = 0, Name = "Additional New Item" });
            }

        }
        [Command]
        public void DeleteItem() {
            if (List != null && List.Count > 0) {
                List.RemoveAt(List.Count - 1);
            }
        }
    }
}
