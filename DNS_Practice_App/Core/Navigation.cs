using DNS_Practice_App.Core.Base;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DNS_Practice_App.Core;

internal static class Navigation
{
    private static readonly List<Page> _pages = new();
    private static int _pageIndex = 0;

    public static NavigationalViewModel NavigationModel { get; set; } = null!;

    public static void DisplayPage<T> () where T : Page
    {
        var page = Activator.CreateInstance<T>();

        if (_pageIndex < _pages.Count - 1) {
            _pages.RemoveRange(_pageIndex + 1, _pages.Count - _pageIndex - 1);
        }

        _pages.Add(page);
        _pageIndex = _pages.Count - 1;

        NavigationModel.CurrentPage = _pages[_pageIndex];
    }

    public static void DisplayNext ()
    {
        if (_pageIndex >= _pages.Count - 1)
            return;

        NavigationModel.CurrentPage = _pages[++_pageIndex];
    }

    public static void DisplayPrevious ()
    {
        if (_pageIndex <= 0)
            return;

        NavigationModel.CurrentPage = _pages[--_pageIndex];
    }
}