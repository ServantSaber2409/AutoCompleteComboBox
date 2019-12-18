using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoCompleteComboBox
{
    public class AutoCompleteComboBoxSource : IAutoCompleteSource
    {
        private int _id;
        private string _username;
        private string _usernet;

        public AutoCompleteComboBoxSource(int id, string username, string usernet)
        {
            _id = id;
            _username = username;
            _usernet = usernet;
        }

        public int Id { get => _id; set => _id = value; }
        public string UserName { get => _username; set => _username = value; }
        public string UserNet { get => _usernet; set => _usernet = value; }
    }   

    public interface IAutoCompleteSource
    {
        int Id { set; get; }
        string UserName { set; get; }
        string UserNet { set; get; }
    }

    public enum SearchType
    {
        UserName = 1,
        UserNet = 2
    }

    public class AutoCompleteSearchTypes
    {
        public AutoCompleteSearchTypes()
        {
            _searchType = SearchType.UserName;
        }

        private SearchType _searchType;

        public SearchType SearchType { get => _searchType; set => _searchType = value; }
    }
}
