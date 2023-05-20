using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using учет_бюджета4.Commands;

namespace учет_бюджета4.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private DateTime? selectedDate;
        private Note newNote = new Note();
        private Note selectedNote;

        public DateTime? SelectedDate
        {
            get => selectedDate;
            set
            {
                if (value != selectedDate)
                {
                    selectedDate = value;
                    OnPropertyChanged();
                    OnDateChanged(value);
                }
            }
        }
        public Note NewNote 
        { 
            get => newNote;
            set 
            { 
                if(value != newNote)
                {
                    newNote = value;
                    OnPropertyChanged();
                }
            }
        }

        public Note SelectedNote 
        { 
            get => selectedNote;
            set 
            { 
                if(value != selectedNote)
                {
                    selectedNote = value;
                    OnPropertyChanged();

                    if(value == null)
                    {
                        NewNote = new Note();
                    }
                    else
                    {
                        NewNote = new Note
                        {
                            Money = value.Money,
                            Date = value.Date,
                            IsIncome = value.IsIncome,
                            Name = value.Name,
                            TypeName = value.TypeName
                        };
                    }
                }
            }
        }

        public MainViewModel()
        {
            CollectionView = (CollectionView)CollectionViewSource.GetDefaultView(Notes);
        }

        Predicate<object> predicate;

        private void OnDateChanged(DateTime? value)
        {
            if (value.HasValue)
            {
                predicate = x =>
                {
                    var item = (Note)x;
                    return item.Date == value.Value.Date;
                };

            }
            else
            {
                predicate = null;
            }
            CollectionView.Filter = predicate;
            UpdateSum();
        }

        private void UpdateSum()
        {
            TotalSum = Notes.Where(x => predicate?.Invoke(x) ?? true).Sum(x => Math.Abs(x.Money));
        }

        public CollectionView CollectionView { get; set; }

        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public ObservableCollection<string> TypeNames { get; } = new ObservableCollection<string>();

        public ICommand AddNewNoteCommand => new MyCommand(AddNewNote);
        public ICommand AddNewTypeNameCommand => new MyCommand(AddNewTypeName);
        public ICommand EditNewTypeNameCommand => new MyCommand(EditNewTypeName);
        public ICommand DeleteNewTypeNameCommand => new MyCommand(DeleteNewTypeName);

        private void EditNewTypeName(object obj)
        {
            if(SelectedNote != null)
            {
                SelectedNote.Date = newNote.Date;
                SelectedNote.Name = newNote.Name;
                SelectedNote.Money = newNote.Money;
                SelectedNote.TypeName = newNote.TypeName;
                SelectedNote.IsIncome = newNote.Money >= 0;
                UpdateSum();
            }
        }

        public decimal TotalSum { get; private set; }

        private void DeleteNewTypeName(object obj)
        {
            if(SelectedNote != null)
            {
                Notes.Remove(SelectedNote);
                CollectionView.Refresh();
                UpdateSum();
            }
        }

        public void AddNewNote(object param)
        {
            newNote.IsIncome = newNote.Money >= 0;
            newNote.Date = new DateTime(2023, 3, new Random().Next(1, 20));
            Notes.Add(newNote);
            NewNote = new Note();
            UpdateSum();
        }
        


        public void AddNewTypeName(object param)
        {
            NewWindow newWindow = new NewWindow();

            var dc = (TypeNameViewModel)newWindow.DataContext;

            dc.OnAddCommand = new MyCommand(x =>
            {
                if(dc.TypeName != null)
                {
                    TypeNames.Add(dc.TypeName);
                    newWindow.Close();
                }
            });

            newWindow.ShowDialog();
        }

    }
}
