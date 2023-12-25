using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;


namespace ez3.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private ObservableCollection<UtilityService> _utilityServices;
        public ObservableCollection<UtilityService> UtilityServices
        {
            get => _utilityServices;
            set => this.RaiseAndSetIfChanged(ref _utilityServices, value);
        }

        private ReactiveCommand<Unit, Unit> _addCommand;
        public ReactiveCommand<Unit, Unit> AddCommand => _addCommand ??= ReactiveCommand.Create(AddUtilityService);

        private void AddUtilityService()
        {
            using (var context = new AppDbContext())
            {
                var newService = new UtilityService { Name = "Комуналка" }; 
                context.UtilityServices.Add(newService);
                context.SaveChanges();
            }

            LoadUtilityServices(); 
        }

        private void LoadUtilityServices()
        {
            using (var context = new AppDbContext())
            {
                UtilityServices = new ObservableCollection<UtilityService>(context.UtilityServices.ToList());
            }
        }
    }

}
