using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace Vereinsverwaltung.ViewModel;
public partial class ContributionViewModel : ViewModelBase
{
    public bool IsItemSelected => SelectedItem != null;

    [ObservableProperty]
    private ObservableCollection<ContributionScaleItem> contributionScalings;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsItemSelected))]
    private ContributionScaleItem selectedItem;
    private readonly IDialogService dialogService;

    public ContributionViewModel(DataAccessor dataAccessor, ResourceLoader resourceLoader,
        IDialogService dialogService) : base(dataAccessor, resourceLoader)
    {
        this.dialogService = dialogService;
    }

    [RelayCommand]
    private async Task LoadContributionScaling()
    {
        var scaling = await dataAccessor.ContributionScale.Value;

        ContributionScalings = new ObservableCollection<ContributionScaleItem>(scaling.Items);
    }

    [RelayCommand]
    private async Task CreateContributionScale()
    {
        var dialogViewModel = App.ServiceProvider.GetRequiredService<CreateContributionScaleViewModel>();
        if (await dialogService.ShowAsync(dialogViewModel))
        {
            var scaleItem = new ContributionScaleItem()
            {
                Id = Guid.NewGuid(),
                Contribution = dialogViewModel.Contribution,
                Employment = dialogViewModel.Employment,
                MaxAge = dialogViewModel.MaxAge,
                MinAge = dialogViewModel.MinAge,
            };

            var currentScaling = await dataAccessor.ContributionScale.Value;
            
            ContributionScalings.Add(scaleItem);
            currentScaling.Items = ContributionScalings;

            await dataAccessor.SetContributionScaling(currentScaling);
        }
    }

    [RelayCommand]
    private async Task DeleteContributionScale()
    {
        if (await dialogService.ShowAsync(App.ServiceProvider.GetRequiredService<ConfirmActionViewModel>()))
        {
            if (SelectedItem != null)
            {
                var currentScale = await dataAccessor.ContributionScale.Value;
                var scaleToDelete = currentScale.Items.Where(m => m.Id == SelectedItem.Id).FirstOrDefault();

                if (scaleToDelete != null)
                {
                    ContributionScalings.Remove(scaleToDelete);
                    currentScale.Items = ContributionScalings;
                    await dataAccessor.SetContributionScaling(currentScale);
                }
            }
        }
    }
}
