using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Laboration3;
using System.Collections.ObjectModel;
using System.Threading;


namespace WpfApplication1
{
    
    public class MainViewModel : ObservableObject
    {
        
        public MainViewModel()
        {
            _mess = new BaseMessage();            
        }

        

        public static ObservableCollection<BaseMessage> messageBox = new ObservableCollection<BaseMessage>();
        public static ObservableCollection<string> contactBook = new ObservableCollection<string>();

        public ObservableCollection<string> ContactList
        {
            get
            {
                return contactBook;
            }
        }

        public ObservableCollection<BaseMessage> MyList
        {
            get
            {
                return messageBox;
            }            
        }       

        private BaseMessage _mess;
        public BaseMessage Mess
        {
            get
            {
                return _mess;
            }
            set
            {
                _mess = value;                
            }
        }
        public BaseMessage MySelectedItem
        {
            get;
            set;
        }

        public string MyItem
        {
            get;
            set;          
        }

        private int _test;
        public int test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                OnPropertyChanged("test");
            }
        }

        //adapter => new CommandHandler(ChangeText); istället för get/set
        //{
        //    get { return new CommandHandler(CreateNewMessage); }
        //}

        public ICommand NewMessage => new CommandHandler(CreateNewMessage);        
        private void CreateNewMessage()
        {
            if (Mess.Reciever != null && Mess.Sender !=null)
            {
                _mess.Time = Convert.ToString(DateTime.Now);
                messageBox.Add(_mess);
                _mess = new BaseMessage();
                OnPropertyChanged("Mess");
            }
        }

        public ICommand SaveTheMessage => new CommandHandler(SavingMail);        
        private void SavingMail()
        {
            BinarySerialization.WriteToBinaryFile<ObservableCollection<BaseMessage>>(@"C:\Users\X\Desktop\Lab\Test.bin", messageBox);
        }

        

        public ICommand LoadTheMessage => new CommandHandler(LoadMail);        
        private async void LoadMail()
        {
            await DoWork();
            
        }
        private async Task DoWork()
        {
            await Task.Run(() =>
            {
                
                for (int i = 0; i <= 100; i++)
                {
                    test = i;
                    Thread.Sleep(100);
                }
                
                messageBox = BinarySerialization.ReadFromBinaryFile<ObservableCollection<BaseMessage>>(@"C:\Users\X\Desktop\Lab\Test.bin");
                OnPropertyChanged("MyList");
            });
        }

        


        public ICommand RemoveMessage => new CommandHandler(DeleteEmail);       
        private void DeleteEmail()
        {
            MyList.Remove(MySelectedItem);            
        }

        public ICommand ClearMessages => new CommandHandler(ClearAllMessages);        
        private void ClearAllMessages()
        {
            MyList.Clear();
        }

        public ICommand Exit => new CommandHandler(ExitApp);        
        private void ExitApp()
        {
            BinarySerialization.WriteToBinaryFile<ObservableCollection<string>>(@"C:\Users\X\Desktop\Lab\contacts.bin", contactBook);
            Environment.Exit(0);
        }

        public ICommand SaveContacts => new CommandHandler(SContacts);
        private void SContacts()
        {            
            contactBook.Add(Mess.Reciever);            
        }

        public ICommand LoadContacts => new CommandHandler(LContacts);
        private void LContacts()
        {
            contactBook = BinarySerialization.ReadFromBinaryFile<ObservableCollection<string>>(@"C:\Users\X\Desktop\Lab\contacts.bin");
            OnPropertyChanged("ContactList");
        }

        public ICommand UseContacts => new CommandHandler(UContacts);
        private void UContacts()
        {
            Mess.Reciever = MyItem;
            OnPropertyChanged("Mess");
        }

        public ICommand ReadMessage => new CommandHandler(RMessage);
        private void RMessage()
        {
            Mess = MySelectedItem;
            OnPropertyChanged("Mess");
        }
    }
    }




