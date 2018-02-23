using System.Collections.Generic;
using Vidly.Web.Models;

namespace Vidly.Web.ViewModels
{
    public class RandomMovieCustomersViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}