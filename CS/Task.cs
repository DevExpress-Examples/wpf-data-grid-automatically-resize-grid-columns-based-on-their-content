using DevExpress.Mvvm;

namespace E2042 {
    public class Task : BindableBase {
        public int Num { get { return GetValue<int>(); } set { SetValue(value); } }
        public string Name { get { return GetValue<string>(); } set { SetValue(value); } }
        public bool IsCompleted { get { return GetValue<bool>(); } set { SetValue(value); } }
    }
}
