using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class DocumentsViewModel : ViewModel
{
    private List<IEnumerable<Document>> _docsOrig;

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

    public List<IEnumerable<Document>> Documents { get; set; }

    public override void Initialize ()
    {
        _docsOrig = _repository.GetData().ToList();
        Documents = _docsOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Documents = _docsOrig.ToList();
        } else {
            for (int i = 0; i < _docsOrig.Count; i++) {
                Documents[i] = _repository.FilterList(_docsOrig[i], SearchText);
            }
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Documents));
    }
}