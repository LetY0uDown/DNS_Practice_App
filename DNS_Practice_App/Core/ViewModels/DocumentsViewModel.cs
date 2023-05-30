using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class DocumentsViewModel : ViewModel
{
    private List<Document> _docsOrig;

    private readonly IFilter<Document> _filter;
    private readonly MySqlDatabase _mySqlDatabase;
    private string _searchString;

    public DocumentsViewModel (IFilter<Document> filter, MySqlDatabase mySqlDatabase)
    {
        _filter = filter;
        _mySqlDatabase = mySqlDatabase;
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

    public List<Document> Documents { get; set; }

    public override void Initialize ()
    {
        _docsOrig = _mySqlDatabase.Get<Document>().ToList();
        Documents = _docsOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Documents = _docsOrig.ToList();
        } else {
            Documents = _filter.FilterList(_docsOrig, SearchText).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Documents));
    }
}