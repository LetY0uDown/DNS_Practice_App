using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class DocumentsViewModel : ViewModel
{
    private string _searchString;

    public DocumentsViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Documents_1 = context.Documents.ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Documents_2 = context2.Documents.ToList();
            }
        }
    }

    public string SearchText
    {
        get => _searchString;
        set {
            _searchString = value;

            if (string.IsNullOrEmpty(value)) {
                using (var context = new DNS_practiceContext_One()) {
                    Documents_1 = context.Documents.ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Documents_2 = context2.Documents.ToList();
                    }
                }
            }

            Documents_1 = Documents_1.Where(e => e.Name.ToLower().Contains(value.ToLower())).ToList();
            Documents_2 = Documents_2.Where(e => e.Name.ToLower().Contains(value.ToLower())).ToList();

            OnPropertyChanged(nameof(Documents_1));
            OnPropertyChanged(nameof(Documents_2));
        }
    }

    public List<Document> Documents_1 { get; set; }
    public List<Document> Documents_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}