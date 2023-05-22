using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class DocumentsViewModel : ViewModel
{
    private IEnumerable<Document> _docs1Orig;
    private IEnumerable<Document> _docs2Orig;

    private readonly IRepository<Document> _repository;
    private string _searchString;

    public DocumentsViewModel (IRepository<Document> repository)
    {
        _repository = repository;

        UpdateList = new(o => {
            Initialize();
            UpdateUI();
        });
    }

    public string SearchText
    {
        get => _searchString;
        set {
            _searchString = value;
            Search();
        }
    }

    public UICommand UpdateList { get; private init; }

    public List<Document> Documents_1 { get; set; }
    public List<Document> Documents_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _docs1Orig = _repository.GetFromFirstDB();
        _docs2Orig = _repository.GetFromSecondDB();

        Documents_1 = _docs1Orig.ToList();
        Documents_2 = _docs2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Documents_1 = _docs1Orig.ToList();
            Documents_2 = _docs2Orig.ToList();
        } else {
            Documents_1 = _docs1Orig.Where(e => e.Name.ToLower().Contains(SearchText.ToLower())).ToList();
            Documents_2 = _docs2Orig.Where(e => e.Name.ToLower().Contains(SearchText.ToLower())).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Documents_1));
        OnPropertyChanged(nameof(Documents_2));
    }
}